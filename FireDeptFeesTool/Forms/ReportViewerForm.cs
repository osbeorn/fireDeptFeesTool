using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace FireDeptFeesTool.Forms
{
    public partial class ReportViewerForm : Form
    {
        private static ReportViewerForm instance;

        public ReportViewerForm()
        {
            InitializeComponent();
        }

        public ReportViewerForm(string reportPath, ReportDataSource dataSource, List<ReportParameter> parameters)
        {
            InitializeComponent();
            InitializeReport(reportPath, dataSource, parameters);
        }

        public ReportViewerForm(MemoryStream reportDefinition, ReportDataSource dataSource, List<ReportParameter> parameters)
        {
            InitializeComponent();
            InitializeCustomReport(reportDefinition, dataSource, parameters);
        }

        private void InitializeReport(string reportPath, ReportDataSource dataSource, List<ReportParameter> parameters)
        {
            reportViewer.Reset();
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            reportViewer.LocalReport.DataSources.Add(dataSource);
            reportViewer.LocalReport.SetParameters(parameters);
        }

        private void InitializeCustomReport(Stream reportDefinition, ReportDataSource dataSource, List<ReportParameter> parameters)
        {
            reportViewer.Reset();
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.LoadReportDefinition(reportDefinition);
            reportViewer.LocalReport.DataSources.Add(dataSource);
            reportViewer.LocalReport.SetParameters(parameters);
        }

        public void SetReport(string reportPath, ReportDataSource dataSource, List<ReportParameter> parameters)
        {
            InitializeReport(reportPath, dataSource, parameters);
            ShowReport();
        }

        public void SetCustomReport(MemoryStream reportDefinition, ReportDataSource dataSource, List<ReportParameter> parameters)
        {
            InitializeCustomReport(reportDefinition, dataSource, parameters);
            ShowReport();
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            reportViewer.RefreshReport();
        }

        public static ReportViewerForm GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ReportViewerForm();
            }

            return instance;
        }

        private void ShowReport()
        {
            Show();
            Focus();
            reportViewer.RefreshReport();
        }
    }
}