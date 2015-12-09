using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireDeptFeesTool.Model.Main
{
    [Table("fee_logs", Schema = "public")]
    public partial class FeeLogs
    {
        [Key, Column("year", Order = 0)]
        public int Year { get; set; }

        [Key, ForeignKey("Member"), Column("vulkan_id", Order = 1)]
        public string VulkanID { get; set; }

        [Column("payment_status"), Required]
        public PaymentStatusEnum PaymentStatus { get; set; }

        [Column("fee_payed")]
        public Nullable<decimal> FeePayed { get; set; }

        [Column("fee_to_pay")]
        public Nullable<decimal> FeeToPay { get; set; }

        public virtual Member Member { get; set; }
    }
}
