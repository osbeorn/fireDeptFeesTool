using System.Collections.Generic;
using FireDeptFeesTool.ReportModels;
using FireDeptFeesTool.ViewModels;

namespace FireDeptFeesTool.DataSets
{
    public class PaymentDebtsDataSet
    {
        public PaymentDebtsDataSet(List<DebtorReportModel> list)
        {
            Debtors = list;
        }

        public List<DebtorReportModel> Debtors { get; set; }
    }
}