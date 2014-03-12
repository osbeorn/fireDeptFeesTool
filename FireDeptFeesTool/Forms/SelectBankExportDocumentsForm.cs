using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FireDeptFeesTool.Controls;
using FireDeptFeesTool.Model;
using FireDeptFeesTool.ViewModels;

namespace FireDeptFeesTool.Forms
{
    public partial class SelectBankExportDocumentsForm : Form
    {
        private readonly PaymentsListControl owner;

        public SelectBankExportDocumentsForm()
        {
            InitializeComponent();
        }

        public SelectBankExportDocumentsForm(List<BankExportDocumentSelectionViewModel> docs, PaymentsListControl owner)
        {
            this.owner = owner;

            InitializeComponent();
            InitializeDataGridView(docs);
        }

        public void InitializeDataGridView(List<BankExportDocumentSelectionViewModel> docs)
        {
            var memberCol = dataGridView1.Columns["Member"] as DataGridViewComboBoxColumn;
            if (memberCol != null)
            {
                using (var db = new FeeStatusesDBContext())
                {
                    memberCol.DataSource =
                        db.Member
                            .Where(m => m.MustPay && m.Active)
                            .OrderBy(m => m.Surname)
                            .ThenBy(m => m.Name)
                            .ToList();

                    memberCol.ValueMember = "VulkanID";
                    memberCol.DisplayMember = "SurnameAndNameWithVulkanID";
                    memberCol.AutoComplete = true;
                }
            }

            dataGridView1.DataSource = docs;
            ClearSelection();
        }

        /* OBSOLETE
        public List<BankExportDocumentSelectionViewModel> GetDataSource(List<BankExportDocument> docs)
        {
            var retList = new List<BankExportDocumentSelectionViewModel>();

            docs.ForEach(doc =>
                             {
                                int? year = null;
                                string vulkanId = null;

                                if (doc.SklicOdobritve.Contains("-"))
                                {
                                    year = int.Parse(doc.SklicOdobritve.Split('-')[0]);
                                    vulkanId = doc.SklicOdobritve.Split('-')[1];
                                }

                                 //var member = _db.Member.Find(id);
                                 //member.FeeLogs.Single(fl => fl.Year == year).PaymentStatusID = PaymentStatusID.PLACAL;

                                retList.Add(
                                    new BankExportDocumentSelectionViewModel
                                        {
                                            Member = vulkanId,
                                            Years = year.HasValue ? year.Type.ToString() : "",
                                            BankDocData = doc.NazivPartnerja + "; " + doc.Namen + "; " + doc.Znesek + "€",
                                            //Warning = doc.Znesek > 10,
                                            Selected = (vulkanId != null && year.HasValue && doc.Znesek == 10)
                                        }
                                    );
                             });

            return retList;
        }
        */

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() == typeof (DataGridViewComboBoxEditingControl))
            {
                ((ComboBox) e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox) e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox) e.Control).AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }

        private void DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dataGridView1.Rows[e.RowIndex].DataBoundItem as BankExportDocumentSelectionViewModel;
                if (row != null && row.Warning)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }

        private void FinishImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new FeeStatusesDBContext())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var dataRow = row.DataBoundItem as BankExportDocumentSelectionViewModel;
                        if (dataRow == null || !dataRow.Selected) continue;

                        List<int> years = dataRow.Years.Split(',').Select(int.Parse).ToList();
                        Member member = db.Member.Find(dataRow.Member);

                        years.ForEach(member.AddDefaultFeeLogForYear);
                        member.FeeLogs.Where(fl => years.Contains(fl.Year)).ToList().ForEach(
                            fl => fl.PaymentStatusID = PaymentStatus.PLACAL);
                    }

                    db.SaveChanges();
                }
                owner.BindData(true);
            }
            catch (Exception)
            {
            }
            finally
            {
                Exit();
            }
        }

        private void Exit()
        {
            Hide();
            Dispose();
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(CultureInfo.InvariantCulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 25, e.RowBounds.Location.Y + 4);
            }
        }

        private void ClearSelection()
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_VisibleChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void CancelImportButton_Click(object sender, EventArgs e)
        {
            Exit();
        }
    }
}