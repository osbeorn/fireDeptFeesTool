using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FireDeptFeesTool.Forms;
using FireDeptFeesTool.Helpers;
using FireDeptFeesTool.Lib;
using FireDeptFeesTool.Model;
using FireDeptFeesTool.ReportModels;
using Microsoft.Reporting.WinForms;

namespace FireDeptFeesTool.Controls
{
    public partial class RemindersListControl : IListControl
    {
        public const string REPORT_NAME = "FireDeptFeesTool.Reports.DebtorsListReport.rdlc";

        private int maxYear;
        private int minYear;
        private IEnumerable<int> yearsGlobal;

        public RemindersListControl(ShellForm container) : base(container)
        {
            InitializeComponent();

            DrawHelper.EnableControlDoubleBuffering("DataGridView", paymentDebtsDataGridView);
        }

        public void InitializePaymentDebtsDataGridView()
        {
            BindPaymentDebtsDataGridView(null, null, true);
            BindYearRangeComboBoxes(minYear, maxYear);
        }

        public void BindPaymentDebtsDataGridView(int? min, int? max, bool allYears)
        {
            using (var db = new FeeStatusesDBContext())
            {
                var members =
                    allYears
                        ? db.Member.Where(
                            m =>
                            m.MustPay && m.Active && m.FeeLogs.Any(fl => fl.PaymentStatusID == PaymentStatus.NI_PLACAL))
                              .OrderBy(m => m.Surname).ThenBy(m => m.Name)
                        : db.Member.Where(
                            m =>
                            m.MustPay && m.Active &&
                            m.FeeLogs.Any(
                                fl => fl.PaymentStatusID == PaymentStatus.NI_PLACAL && fl.Year >= min && fl.Year <= max))
                              .OrderBy(m => m.Surname).ThenBy(m => m.Name);

                var feeLogs =
                    allYears
                        ? members.SelectMany(m => m.FeeLogs.Where(fl => fl.PaymentStatusID == PaymentStatus.NI_PLACAL)).
                              ToList() // tudi NI_PODATKA ??
                        : members.SelectMany(
                            m =>
                            m.FeeLogs.Where(
                                fl => fl.PaymentStatusID == PaymentStatus.NI_PLACAL && fl.Year >= min && fl.Year <= max))
                              .ToList(); // tudi NI_PODATKA ??

                IEnumerable<int> yearsLocal = null;
                if (feeLogs.Count > 0)
                {
                    maxYear = max.HasValue ? max.Value : feeLogs.Max(l => l.Year);
                    minYear = min.HasValue ? min.Value : feeLogs.Min(l => l.Year);

                    yearsLocal = Enumerable.Range(minYear, maxYear - minYear + 1);

                    if (yearsGlobal == null)
                    {
                        yearsGlobal = yearsLocal;
                    }

                    DataGridViewCheckBoxColumn col;

                    for (int i = 0; i < yearsLocal.Count(); i++)
                    {
                        int year = yearsLocal.ElementAt(i);
                        if (!paymentDebtsDataGridView.Columns.Contains("Year" + year))
                        {
                            col = new DataGridViewCheckBoxColumn
                                      {
                                          Name = "Year" + year,
                                          HeaderText = year.ToString(CultureInfo.InvariantCulture),
                                          DataPropertyName = "Year" + year
                                      };
                            paymentDebtsDataGridView.Columns.Insert(2 + i, col);
                        }
                    }
                }

                // create a DataTable to hold our data ...
                DataTable dt = CreateDataTable(yearsLocal);

                object[] values;
                foreach (Member member in members)
                {
                    values = new object[yearsLocal.Count() + 2];
                    // +2 = member.OldVulkanID in member.OldSurname + " " + member.OldName

                    values[0] = member.VulkanID;
                    values[1] = member.Surname + " " + member.Name;

                    IEnumerable<int> logs =
                        member.FeeLogs.Where(fl => fl.PaymentStatusID == PaymentStatus.NI_PLACAL).Select(fl => fl.Year);
                    for (int i = 2; i < values.Length; i++)
                    {
                        if (logs.Contains(yearsLocal.ElementAt(i - 2)))
                        {
                            values[i] = true;
                        }
                        else
                        {
                            values[i] = DBNull.Value;
                        }
                    }

                    dt.Rows.Add(values);
                }

                paymentDebtsDataGridView.DataSource = dt;
                ClearSelection(paymentDebtsDataGridView);
            }
        }

        public DataTable CreateDataTable(IEnumerable<int> years)
        {
            var dt = new DataTable();
            dt.Columns.Add("MemberVulkanID", typeof (String));
            dt.Columns.Add("MemberSurnameAndName", typeof (String));

            if (years != null)
            {
                foreach (int year in years)
                {
                    dt.Columns.Add("Year" + year, typeof (Boolean));
                }
            }

            return dt;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (paymentDebtsDataGridView.Rows.Count < 1)
            {
                MessageBox.Show(WindowMessages.NO_DATA_AVAILABLE_FOR_PRINT, WindowMessages.WARNING_TITLE);
                return;
            }

            //new ReportViewerForm(REPORT_NAME, GetReportDataSet(), new List<ReportParameter>()).Show();
            
            //form.SetReport(selectedStat.ReportPath, selectedStat.DataSource, selectedStat.Parameters);

            ReportViewerForm.GetInstance().SetReport(
                REPORT_NAME,
                GetReportDataSet(),
                new List<ReportParameter>()
            );
        }

        private ReportDataSource GetReportDataSet()
        {
            var debtors = new List<DebtorReportModel>();

            using (var db = new FeeStatusesDBContext())
            {
                foreach (DataGridViewRow row in paymentDebtsDataGridView.Rows)
                {
                    object[] data = (row.DataBoundItem as DataRowView).Row.ItemArray;
                    var cols = new List<int>();
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].Equals(true))
                        {
                            cols.Add(i);
                        }
                    }

                    if (cols.Count > 0)
                    {
                        Member member = db.Member.Find(data[0].ToString());
                        var debtor = new DebtorReportModel
                                         {
                                             RepDefinition =
                                                 ConfigHelper.GetConfigValue<string>(ConfigFields.DEBTS_TEMPLATE),
                                             FirstName = member.Name,
                                             LastName = member.Surname,
                                             DebtSum =
                                                 10*cols.Count // TODO - fix this !!!
                                         };

                        var yearsList = new List<short>();
                        foreach (int c in cols)
                        {
                            yearsList.Add(short.Parse(paymentDebtsDataGridView.Columns[c].HeaderText));
                        }

                        debtor.YearsList = yearsList;

                        debtors.Add(debtor);
                    }
                }
            }

            return new ReportDataSource("DataSet1", debtors);
        }

        private void BindYearRangeComboBoxes(int minYear, int maxYear)
        {
            List<int> yearsToList =
                yearsGlobal == null
                    ? new List<int>()
                    : yearsGlobal.ToList();

            List<int> yearsFromList =
                yearsGlobal == null
                    ? new List<int>()
                    : yearsGlobal.Where(y => y >= minYear).ToList();

            yearFromComboBox.SelectedIndexChanged -= YearFromComboBox_SelectedIndexChanged;
            yearToComboBox.SelectedIndexChanged -= YearToComboBox_SelectedIndexChanged;

            yearFromComboBox.DataSource = yearsToList;
            yearFromComboBox.SelectedIndex = yearsToList.IndexOf(minYear);

            yearToComboBox.DataSource = yearsFromList;
            yearToComboBox.SelectedIndex = yearsFromList.IndexOf(maxYear);

            yearFromComboBox.SelectedIndexChanged += YearFromComboBox_SelectedIndexChanged;
            yearToComboBox.SelectedIndexChanged += YearToComboBox_SelectedIndexChanged;
        }

        private void PaymentDebtsDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1 && e.Value == DBNull.Value)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Handled = true;
            }
        }

        private void PaymentDebtsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (paymentDebtsDataGridView[e.ColumnIndex, e.RowIndex].Value == DBNull.Value)
            {
                e.Cancel = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }

        private void YearFromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearToComboBox.SelectedIndexChanged -= YearToComboBox_SelectedIndexChanged;

            List<int> yearsToList = yearsGlobal.Where(y => y >= (int) yearFromComboBox.SelectedItem).ToList();
            yearToComboBox.DataSource = yearsToList;
            yearToComboBox.SelectedIndex = yearsToList.IndexOf(yearsToList.Last());

            BindPaymentDebtsDataGridView(yearFromComboBox.SelectedItem as int?, yearToComboBox.SelectedItem as int?,
                                         false);

            yearToComboBox.SelectedIndexChanged += YearToComboBox_SelectedIndexChanged;
        }

        private void YearToComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPaymentDebtsDataGridView(yearFromComboBox.SelectedItem as int?, yearToComboBox.SelectedItem as int?,
                                         false);
        }

        public override void BindData(bool overrideDefaultFlow)
        {
            if (!overrideDefaultFlow && !RefreshOnNextLoad) return;

            FillYearsList();

            var yearFrom = yearFromComboBox.SelectedItem as int?;
            var yearTo = yearToComboBox.SelectedItem as int?;

            if (yearFrom.HasValue && !yearsGlobal.Contains(yearFrom.Value))
            {
                yearFrom = yearsGlobal.Min();
            }
            if (yearTo.HasValue && !yearsGlobal.Contains(yearTo.Value))
            {
                yearTo = yearsGlobal.Max();
            }

            BindPaymentDebtsDataGridView(yearFrom, yearTo, !(yearFrom.HasValue && yearTo.HasValue));
            BindYearRangeComboBoxes(minYear, maxYear);

            RefreshOnNextLoad = false;
        }

        private void FillYearsList()
        {
            using (var db = new FeeStatusesDBContext())
            {
                IOrderedQueryable<Member> members =
                    db.Member.Where(
                        m => m.MustPay && m.Active && m.FeeLogs.Any(fl => fl.PaymentStatusID == PaymentStatus.NI_PLACAL))
                        .OrderBy(m => m.Surname).ThenBy(m => m.Name);
                List<FeeLogs> feeLogs =
                    members.SelectMany(m => m.FeeLogs.Where(fl => fl.PaymentStatusID == PaymentStatus.NI_PLACAL)).ToList
                        ();

                if (feeLogs.Count > 0)
                {
                    maxYear = feeLogs.Max(l => l.Year);
                    minYear = feeLogs.Min(l => l.Year);

                    yearsGlobal = Enumerable.Range(minYear, maxYear - minYear + 1);
                }
            }
        }

        public override void SaveChanges(bool notifyUser)
        {
        }

        public override void OnClosing()
        {
        }

        private void PaymentDebtsDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var b = new SolidBrush(paymentDebtsDataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                                      e.RowBounds.Location.X + 25, e.RowBounds.Location.Y + 4);
            }
        }

        private void RemindersListControl_VisibleChanged(object sender, EventArgs e)
        {
            ClearSelection(paymentDebtsDataGridView);
        }

        private void PrepareRemindersButton_Click(object sender, EventArgs e)
        {
            InitializePaymentDebtsDataGridView();
        }
    }
}