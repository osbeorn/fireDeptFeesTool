using FireDeptFeesTool.Model.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDeptFeesTool.Model.View
{
    public class PaymentLogsViewModel
    {
        public PaymentLogsViewModel()
        {
        }

        public PaymentLogsViewModel(bool? paid, short year, PaymentStatusEnum status)
        {
            Year = year;
            Status = status;
        }

        public short Year { get; set; }
        public PaymentStatusEnum Status { get; set; }
    }
}
