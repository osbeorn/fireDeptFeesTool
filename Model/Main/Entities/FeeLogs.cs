using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireDeptFeesTool.Model.Main
{
    [Table("feelogs")]
    public partial class FeeLogs
    {
        [Key, Column(Order = 0)]
        public int Year { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Member")]
        public string VulkanID { get; set; }

        [Required]
        public PaymentStatusEnum PaymentStatus { get; set; }

        public Nullable<decimal> FeePayed { get; set; }

        public Nullable<decimal> FeeToPay { get; set; }

        public virtual Member Member { get; set; }
    }
}
