using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DynamicTable;
using FireDeptFeesTool.Forms;
using FireDeptFeesTool.Helpers;
using FireDeptFeesTool.Lib;
using FireDeptFeesTool.Model;
using FireDeptFeesTool.ViewModels;
using Microsoft.Reporting.WinForms;

namespace FireDeptFeesTool.Controls
{
    public partial class PaymentsListControl : IListControl
    {
        private readonly Dictionary<int, IList<int>> _changedCells;
        private bool _dataChanged;

        public PaymentsListControl(ShellForm container)
            : base(container)
        {
            _changedCells = new Dictionary<int, IList<int>>();

            InitializeComponent();
            DrawHelper.EnableControlDoubleBuffering("DataGridView", paymentsDataGridView);
            BindPaymentsDataGridView();
        }

        public bool DataChanged
        {
            get { return _dataChanged; }
        }

        public void BindPaymentsDataGridView()
        {
            paymentsDataGridView.CellValueChanged -= PaymentsDataGridView_CellValueChanged;

            using (var db = new FeeStatusesDBContext())
            {
                IOrderedQueryable<Member> members =
                    db.Member.Where(m => m.MustPay && m.Active).OrderBy(m => m.Surname).ThenBy(m => m.Name);
                List<FeeLogs> feeLogs = members.SelectMany(m => m.FeeLogs).ToList();

                List<PaymentStatus> paymentStatuses = db.PaymentStatus.ToList();
                IEnumerable<int> years = null;
                if (feeLogs != null && feeLogs.Count > 0)
                {
                    int maxYear = feeLogs.Max(l => l.Year);
                    int minYear = feeLogs.Min(l => l.Year);

                    years = Enumerable.Range(minYear, maxYear - minYear + 1);
                    DataGridViewComboBoxColumn col;
                    foreach (int year in years)
                    {
                        if (!paymentsDataGridView.Columns.Contains("Year" + year))
                        {
                            col = new DataGridViewComboBoxColumn
                                      {
                                          DataSource = paymentStatuses,
                                          Name = "Year" + year,
                                          HeaderText = year.ToString(),
                                          DisplayMember = "Text",
                                          ValueMember = "PaymentStatusID",
                                          DataPropertyName = "Year" + year,
                                          FlatStyle = FlatStyle.Flat
                                      };
                            paymentsDataGridView.Columns.Add(col);
                        }
                    }
                }

                // create a DataTable to hold our data ...
                DataTable dt = CreateDataTable(years);

                object[] values;
                foreach (Member member in members)
                {
                    values =
                        years != null
                            ? new object[4 + years.Count()]
                            : new object[4];

                    values[0] = member.VulkanID;
                    values[1] = member.Surname;
                    values[2] = member.Name;
                    values[3] = string.Format("{0} ({1} let)", member.DateOfBirth.ToString("dd.MM.yyyy"),
                                              member.GetMemberAgeForCurrentYear());

                    if (years != null)
                    {
                        int i = 0;
                        foreach (int year in years)
                        {
                            FeeLogs log = member.FeeLogs.FirstOrDefault(l => l.Year == year);
                            values[4 + i] =
                                log != null
                                    ? log.PaymentStatusID
                                    : PaymentStatus.NI_PODATKA;
                            i++;
                        }
                    }

                    dt.Rows.Add(values);
                }

                paymentsDataGridView.DataSource = dt;
                ClearSelection(paymentsDataGridView);
            }

            paymentsDataGridView.CellValueChanged += PaymentsDataGridView_CellValueChanged;
        }

        public DataTable CreateDataTable(IEnumerable<int> years)
        {
            var dt = new DataTable();
            dt.Columns.Add("MemberVulkanID", typeof (String));
            dt.Columns.Add("MemberSurname", typeof (String));
            dt.Columns.Add("MemberName", typeof (String));
            dt.Columns.Add("DateOfBirth", typeof (String));

            if (years != null)
            {
                foreach (int year in years)
                {
                    dt.Columns.Add("Year" + year, typeof (Int32));
                }
            }

            return dt;
        }

        private void PaymentsDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var b = new SolidBrush(paymentsDataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                                      e.RowBounds.Location.X + 25, e.RowBounds.Location.Y + 4);
            }
        }

        private void PaymentsDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridViewCell cell;
            if (e.RowIndex > -1 && e.ColumnIndex > 3 &&
                ((int) e.Value == PaymentStatus.NI_PODATKA || (int) e.Value == PaymentStatus.VETERAN ||
                 (int) e.Value == PaymentStatus.MLADOLETNIK))
            {
                cell = ((DataGridView) sender)[e.ColumnIndex, e.RowIndex];
                cell.Style.BackColor = Color.LightGray;
            }
            if (e.RowIndex > -1 && e.ColumnIndex > 3 && (int) e.Value == PaymentStatus.PLACAL)
            {
                cell = ((DataGridView) sender)[e.ColumnIndex, e.RowIndex];
                cell.Style.BackColor = Color.LightGreen;
            }
            else if (e.RowIndex > -1 && e.ColumnIndex > 3 && (int) e.Value == PaymentStatus.NI_PLACAL)
            {
                cell = ((DataGridView) sender)[e.ColumnIndex, e.RowIndex];
                cell.Style.BackColor = Color.LightSalmon;
            }
            else if (e.ColumnIndex == 3 && paymentsDataGridView.Columns.Count > 4)
            {
                Rectangle rect = e.CellBounds;

                using (var p = new Pen(Color.Black, 4))
                {
                    e.Paint(e.CellBounds, e.PaintParts);
                    e.Graphics.DrawLine(p, new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom));
                    e.Handled = true;
                }
            }
        }

        private void ImportPaymentDataButton_Click(object sender, EventArgs e)
        {
            importDataContextMenuStrip.Show(importPaymentDataButton, new Point(0, importPaymentDataButton.Height));
            /*
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fullFilePath = openFileDialog.FileName;
                string onlyFileName = System.IO.Path.GetFileName(fullFilePath);

                result = MessageBox.Show("Ste prepričani da želite uvoziti podatke iz datoteke \"" + onlyFileName + "\"?", "Uvoz podatkov", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ImportPaymentHistory(fullFilePath);
                    //UpdateMembersDataGridView();
                }
            }
            */
        }

        private void ImportPaymentHistory(string fullFilePath)
        {
            string line;
            var file = new StreamReader(fullFilePath, Encoding.UTF8);

            try
            {
                using (var db = new FeeStatusesDBContext())
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] lineData = line.Split(';');

                        short year = 2001;
                        Member member = db.Member.Find(lineData[0]);
                        if (member != null && member.Gender) // moski
                        {
                            for (int i = 8; i < 20; i++)
                            {
                                string stat = lineData[i];
                                var log = new FeeLogs
                                              {
                                                  Member = member,
                                                  Year = year
                                              };

                                switch (stat)
                                {
                                    case "DA":
                                        log.PaymentStatusID = PaymentStatus.PLACAL;
                                        break;
                                    case "NE":
                                        log.PaymentStatusID = PaymentStatus.NI_PLACAL;
                                        break;
                                    case "VETERAN":
                                        log.PaymentStatusID = PaymentStatus.VETERAN;
                                        break;
                                    case "XXX":
                                        log.PaymentStatusID = PaymentStatus.MLADOLETNIK;
                                        break;
                                    default:
                                        if (member.GetMemberAgeForYear(year) < 18)
                                        {
                                            log.PaymentStatusID = PaymentStatus.MLADOLETNIK;
                                        }
                                        else if (member.GetMemberAgeForYear(year) >= 60)
                                        {
                                            log.PaymentStatusID = PaymentStatus.VETERAN;
                                        }
                                        else
                                        {
                                            log.PaymentStatusID = PaymentStatus.NI_PODATKA;
                                        }
                                        break;
                                }

                                member.FeeLogs.Add(log);
                                year++;
                            }
                        }
                    }

                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (DbEntityValidationResult eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (DbValidationError ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                        ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            BindPaymentsDataGridView();
        }

        private void PaymentsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_dataChanged)
            {
                _dataChanged = true;
            }

            if (_changedCells.ContainsKey(e.RowIndex))
            {
                if (!_changedCells[e.RowIndex].Contains(e.ColumnIndex))
                {
                    _changedCells[e.RowIndex].Add(e.ColumnIndex);
                }
            }
            else
            {
                if (e.RowIndex > -1)
                {
                    _changedCells.Add(e.RowIndex, new List<int> {e.ColumnIndex});
                }
            }
        }

        private void PaymentsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // values dont change on load - they are just being loaded ...
            _dataChanged = false;

            paymentsDataGridView.DataBindingComplete -= PaymentsDataGridView_DataBindingComplete;
        }

        public override void BindData(bool overrideDefaultFlow)
        {
            if (!overrideDefaultFlow && !RefreshOnNextLoad) return;

            BindPaymentsDataGridView();
            ScrollHorizontallyToEnd();

            RefreshOnNextLoad = false;
        }

        public override void SaveChanges(bool notifyUser)
        {
            paymentsDataGridView.EndEdit();

            if (_dataChanged && paymentsDataGridView.Columns.Count > 4)
            {
                if (notifyUser && DialogResult.No == MessageBox.Show(Messages.SAVE_OR_DISCARD_CHANGES_MSG,
                                                                     Messages.SAVE_OR_DISCARD_CHANGES_TITLE,
                                                                     MessageBoxButtons.YesNo,
                                                                     MessageBoxIcon.Warning))
                {
                    ClearChanges();
                    return;
                }

                using (var db = new FeeStatusesDBContext())
                {
                    foreach (int rowIndex in _changedCells.Keys)
                    {
                        var changedRow = paymentsDataGridView.Rows[rowIndex].DataBoundItem as DataRowView;
                        string rowId = changedRow.Row.ItemArray[0].ToString();

                        foreach (int colIndex in _changedCells[rowIndex])
                        {
                            short changedColName = short.Parse(paymentsDataGridView.Columns[colIndex].HeaderText);
                            //YearXXXX

                            FeeLogs log = db.Member.Find(rowId).FeeLogs.SingleOrDefault(l => l.Year == changedColName);
                            if (log != null)
                            {
                                log.PaymentStatusID = (int) changedRow.Row.ItemArray[colIndex];
                            }
                            else
                            {
                                db.FeeLogs.Add(new FeeLogs
                                                   {
                                                       VulkanID = rowId,
                                                       Year = changedColName,
                                                       PaymentStatusID = (int) changedRow.Row.ItemArray[colIndex]
                                                   }
                                    );
                            }
                        }
                    }

                    int result = db.SaveChanges();
                }

                ClearChanges();
                NotifyDependantControlsOfChanges();
            }
        }

        public void ClearChanges()
        {
            _changedCells.Clear();

            _dataChanged = false;
        }

        private void AddOptionButton_Click(object sender, EventArgs e)
        {
            addOptionButtonContextMenuStrip.Show(addOptionButton, new Point(0, addOptionButton.Height));
        }

        private void ScrollHorizontallyToEnd()
        {
            if (paymentsDataGridView.Columns.Count > 4)
            {
                paymentsDataGridView.FirstDisplayedScrollingColumnIndex = paymentsDataGridView.Columns.Count - 1;
            }
        }

        private void AddCurrentYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;

            using (var db = new FeeStatusesDBContext())
            {
                if (db.Member.Any(m => m.MustPay && m.FeeLogs.Any(fl => fl.Year == currentYear)))
                {
                    MessageBox.Show(
                        string.Format(Messages.RECORDS_FOR_YEAR_EXIST_MSG, currentYear),
                        Messages.RECORDS_FOR_YEAR_EXIST_TITLE, MessageBoxButtons.OK
                        );
                    return;
                }
            }

            SaveChanges(true);

            using (var db = new FeeStatusesDBContext())
            {
                if (!db.Member.Where(m => m.MustPay).All(m => m.FeeLogs.Any(fl => fl.Year == currentYear)))
                {
                    db.Member.ToList().ForEach(m => m.AddDefaultFeeLogForCurrentYear());
                    db.SaveChanges();
                }
            }

            BindPaymentsDataGridView();
            ScrollHorizontallyToEnd();
        }

        private void AddSpecificYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectYearDialog = new SelectYearForm();

            if (selectYearDialog.ShowDialog() == DialogResult.OK)
            {
                int selectedYear = selectYearDialog.Year;

                using (var db = new FeeStatusesDBContext())
                {
                    if (db.Member.Any(m => m.MustPay && m.FeeLogs.Any(fl => fl.Year == selectedYear)))
                    {
                        MessageBox.Show(
                            string.Format(Messages.RECORDS_FOR_YEAR_EXIST_MSG, selectedYear),
                            Messages.RECORDS_FOR_YEAR_EXIST_TITLE, MessageBoxButtons.OK
                            );
                        return;
                    }
                }

                SaveChanges(true);

                using (var db = new FeeStatusesDBContext())
                {
                    if (!db.Member.Where(m => m.MustPay).All(m => m.FeeLogs.Any(fl => fl.Year == selectedYear)))
                    {
                        db.Member.ToList().ForEach(m => m.AddDefaultFeeLogForYear(selectedYear));
                        db.SaveChanges();
                    }
                }

                BindPaymentsDataGridView();
                ScrollHorizontallyToEnd();
            }
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            SaveChanges(false);
        }

        public override void OnClosing()
        {
        }

        private void ImportPaymentsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fullFilePath = openFileDialog.FileName;
                string onlyFileName = Path.GetFileName(fullFilePath);

                result =
                    MessageBox.Show(
                        string.Format(Messages.IMPORT_DATA_CONFIRMATION_REQUIRED_MSG, onlyFileName),
                        Messages.IMPORT_DATA_TITLE,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );

                if (result == DialogResult.Yes)
                {
                    ImportPaymentHistory(fullFilePath);
                    //UpdateMembersDataGridView();
                }
            }
        }

        private void ImportBankDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fullFilePath = openFileDialog.FileName;
                string onlyFileName = Path.GetFileName(fullFilePath);

                result =
                    MessageBox.Show(
                        string.Format(Messages.IMPORT_DATA_CONFIRMATION_REQUIRED_MSG, onlyFileName),
                        Messages.IMPORT_DATA_TITLE,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );

                if (result == DialogResult.Yes)
                {
                    ImportBankData(fullFilePath);
                    //UpdateMembersDataGridView();
                }
            }
        }

        private void ImportBankData(string fullFilePath)
        {
            List<BankExportDocumentSelectionViewModel> filteredDocs =
                BankExportDocumentsReader.ParseBankExportDocuments(fullFilePath);

            new SelectBankExportDocumentsForm(filteredDocs, this).Show();
        }

        private void PaymentsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /* OBSOLETE CODE
            if (e.RowIndex > -1 && paymentsDataGridView.Columns[e.ColumnIndex].Name.Contains("Year"))
            {
                using (var db = new FeeStatusesDBContext())
                {
                    var cell = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell; 
                    cell.ToolTipText = PaymentStatus.GetPaymentStatusDesc(cell.Value as int?);
                }
            }
            */
        }

        private void PaymentsListControl_VisibleChanged(object sender, EventArgs e)
        {
            ClearSelection(paymentsDataGridView);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            printButtonContextMenuStrip.Show(printButton, new Point(0, printButton.Height));
        }

        private MemoryStream GetReportDefinition()
        {
            List<ReportColumn> reportColumns = GetReportColumns();

            var ms = new MemoryStream();
            var gen = new RdlGenerator
                          {
                              AllFields = reportColumns,
                              SelectedFields = reportColumns
                          };

            gen.WriteXml(ms);
            ms.Position = 0;

            return ms;
        }

        private List<ReportColumn> GetReportColumns()
        {
            var columns = new List<ReportColumn>
                              {
                                  new ReportColumn {Name = "RowNumber", Value = "#", Width = "0.6cm"},
                                  new ReportColumn {Name = "MemberSurname", Value = "Priimek", Width = "2cm"},
                                  new ReportColumn {Name = "MemberName", Value = "Ime", Width = "2cm"},
                                  new ReportColumn {Name = "DateOfBirth", Value = "Datum rojstva", Width = "2.5cm"},
                              };

            columns.AddRange(
                from DataGridViewColumn column in paymentsDataGridView.Columns
                where column.Name.Contains("Year")
                select new ReportColumn
                           {
                               Name = column.Name,
                               Value = int.Parse(column.Name.Substring(4)).ToString(CultureInfo.InvariantCulture),
                               Width = "1.6cm"
                           }
                );

            return columns;
        }

        private ReportDataSource GetDataSource()
        {
            return new ReportDataSource("DataSet1", paymentsDataGridView.DataSource as DataTable);
        }

        private void PrintPaymentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paymentsDataGridView.Rows.Count < 1)
            {
                MessageBox.Show(Messages.NO_DATA_AVAILABLE_FOR_PRINT, Messages.WARNING_TITLE);
                return;
            }

            new ReportViewerForm(GetReportDefinition(), GetDataSource()).Show();
        }

        private void PrintStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}