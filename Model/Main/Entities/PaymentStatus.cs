using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDeptFeesTool.Model.Main
{
    public class PaymentStatus
    {
        public PaymentStatusEnum Status { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}
