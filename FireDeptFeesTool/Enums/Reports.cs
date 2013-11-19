namespace FireDeptFeesTool.Enums
{
    public enum ReportTypes
    {
        DebtorsListReport
    }

    public class Reports
    {
        public static string GetReportName(ReportTypes rep)
        {
            switch (rep)
            {
                case ReportTypes.DebtorsListReport:
                    return "DebtorsListReport";
                default:
                    return "";
            }
        }
    }
}