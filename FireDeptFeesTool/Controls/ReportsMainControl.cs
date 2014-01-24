using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireDeptFeesTool.Enums;
using FireDeptFeesTool.Forms;
using FireDeptFeesTool.Helpers;
using FireDeptFeesTool.Lib;
using FireDeptFeesTool.ReportModels;
using Microsoft.Reporting.WinForms;
using Report = FireDeptFeesTool.Lib.Reports;

namespace FireDeptFeesTool.Controls
{
    public partial class ReportsMainControl : IListControl
    {
        public ReportsMainControl()
        {
            InitializeComponent();

            FillReportsListBox();
            RenderReportParameterControls();
        }

        private void FillReportsListBox()
        {
            var allReports = Report.GetAll();

            reportsListBox.DataSource = allReports;
            reportsListBox.DisplayMember = "Name";
            reportsListBox.ValueMember = "Type";
        }

        private void RenderReportParameterControls()
        {
            ClearReportsSubControl();

            var selectedStat = (Report) reportsListBox.SelectedItem;
            AddReportsSubControl(selectedStat.ParameterControls);
        }

        private void AddReportsSubControl(List<ReportParameterControl> controls)
        {
            reportsSubControlsPanel.RowCount = controls.Count + 1;

            for (int i = 0; i < controls.Count; i++)
            {
                var control = controls[i];

                var label = new Label {Text = control.Label + ": " };
                label.Anchor = AnchorStyles.Left;
                label.TextAlign = ContentAlignment.MiddleLeft;

                reportsSubControlsPanel.Controls.Add(label, 0, i);
                reportsSubControlsPanel.Controls.Add(control.Control, 1, i);
            }

            reportsSubControlsPanel.Controls.Add(new Control(), 0, reportsSubControlsPanel.RowCount - 1);
            reportsSubControlsPanel.Controls.Add(new Control(), 1, reportsSubControlsPanel.RowCount - 1);
        }

        private void ClearReportsSubControl()
        {
            reportsSubControlsPanel.Controls.Clear();
            reportsSubControlsPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        private List<ReportParameter> GetReportParameterValues()
        {
            var selectedStat = (Report) reportsListBox.SelectedItem;
            var paramControls = selectedStat.ParameterControls;

            var paramValues = new List<ReportParameter>();
            for (int i = 0; i < paramControls.Count; i++)
            {
                var control = reportsSubControlsPanel.GetControlFromPosition(1, i);

                var value = Convert.ChangeType(ControlsHelper.GetValue(control), paramControls[i].ParameterType);
                
                paramValues.Add(new ReportParameter(paramControls[i].Name, value.ToString()));
            }

            return paramValues;
        }

        private Dictionary<string, object> GetQueryParameterValues()
        {
            var selectedStat = (Report)reportsListBox.SelectedItem;
            var paramControls = selectedStat.ParameterControls;

            var paramValues = new Dictionary<string, object>();
            for (var i = 0; i < paramControls.Count; i++)
            {
                var control = reportsSubControlsPanel.GetControlFromPosition(1, i);

                var value = Convert.ChangeType(ControlsHelper.GetValue(control), paramControls[i].ParameterType);

                paramValues.Add(paramControls[i].Name, value);
            }

            return paramValues;
        } 

        private void showReportButton_Click(object sender, EventArgs e)
        {
            var selectedStat = (Report) reportsListBox.SelectedItem;

            var form = ReportViewerForm.GetInstance();
            //form.SetReport(selectedStat.ReportPath, selectedStat.DataSource, selectedStat.Parameters);

            form.SetReport(
                selectedStat.ReportPath,
                selectedStat.GetDataSource(GetQueryParameterValues()),
                GetReportParameterValues()
            );
        }

        private void reportsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderReportParameterControls();
        }
    }
}
