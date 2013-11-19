using System.Collections.Generic;
using FireDeptFeesTool.ViewModels;

namespace FireDeptFeesTool.DataSets
{
    public class PaymentDebtsDataSet
    {
        public PaymentDebtsDataSet(List<DebtorViewModel> list)
        {
            Debtors = list;
        }

        public List<DebtorViewModel> Debtors { get; set; }
    }
}