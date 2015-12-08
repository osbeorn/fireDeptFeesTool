using System.Collections.Generic;
using FireDeptFeesTool.Model.Main;

namespace FireDeptFeesTool.Model.View
{
    public class PaymentViewModel
    {
        public PaymentViewModel()
        {
        }

        public PaymentViewModel(Member member, ICollection<PaymentLogsViewModel> logs)
        {
            Member = member;
            Logs = logs;
        }

        public Member Member { get; set; }
        public ICollection<PaymentLogsViewModel> Logs { get; set; }
    }
}