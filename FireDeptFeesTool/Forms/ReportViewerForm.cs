using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace FireDeptFeesTool.Forms
{
    public partial class ReportViewerForm : Form
    {
        public ReportViewerForm(string reportPath, ReportDataSource dataSource)
        {
            InitializeComponent();
            InitializeReport(reportPath, dataSource);
        }

        public ReportViewerForm(MemoryStream reportDefinition, ReportDataSource dataSource)
        {
            InitializeComponent();
            InitializeCustomReport(reportDefinition, dataSource);
        }

        private void InitializeReport(string reportPath, ReportDataSource dataSource)
        {
            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportEmbeddedResource = reportPath;
            reportViewer1.LocalReport.DataSources.Add(dataSource);
        }

        private void InitializeCustomReport(MemoryStream reportDefinition, ReportDataSource dataSource)
        {
            reportViewer1.Reset();
            reportViewer1.LocalReport.LoadReportDefinition(reportDefinition);
            reportViewer1.LocalReport.DataSources.Add(dataSource);
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}