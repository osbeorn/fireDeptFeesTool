using System.Collections.Generic;
using FireDeptFeesTool.Model.Report;
using FireDeptFeesTool.Model.View;

namespace FireDeptFeesTool.DataSets
{
    public class PaymentDebtsDataSet
    {
        public PaymentDebtsDataSet(List<DebtorReportModel> list)
        {
            Debtors = list;
        }

        public List<MemberStickersDataSet> Bla { get; set; }
        public List<DebtorReportModel> Debtors { get; set; }
    }
}