using System.Collections.Generic;
using FireDeptFeesTool.Model;

namespace FireDeptFeesTool.ViewModels
{
    internal class PaymentViewModel
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

    internal class PaymentLogsViewModel
    {
        public PaymentLogsViewModel()
        {
        }

        public PaymentLogsViewModel(bool? paid, short year, PaymentStatus status)
        {
            Year = year;
            Status = status;
        }

        public short Year { get; set; }
        public PaymentStatus Status { get; set; }
    }
}