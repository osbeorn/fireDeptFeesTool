using System.Data;
using FireDeptFeesTool.Enums;

namespace FireDeptFeesTool.Helpers
{
    public class ReportDatasetHelper
    {
        public static DataSet GetDataSet(ReportTypes report)
        {
            string reportName = Reports.GetReportName(report);
            var ds = new DataSet(reportName + "DataSet");

            switch (report)
            {
            }

            return ds;
        }

        public static DataSet GetDefaultDataSet()
        {
            var ds = new DataSet();
            ds.Tables.Add(new DataTable());

            return ds;
        }
    }
}