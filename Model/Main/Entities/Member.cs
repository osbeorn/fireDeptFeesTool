using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireDeptFeesTool.Model.Main
{
    [Table("member", Schema = "public")]
    public partial class Member
    {
        public Member()
        {
            this.FeeLogs = new HashSet<FeeLogs>();
        }

        [Key, Column("vulkan_id"), MinLength(6), MaxLength(6)]
        public string VulkanID { get; set; }

        [Column("name"), Required, MaxLength(100)]
        public string Name { get; set; }

        [Column("surname"), Required, MaxLength(100)]
        public string Surname { get; set; }

        [Column("date_of_birth"), Required]
        public System.DateTime DateOfBirth { get; set; }

        [Column("address"), Required, MaxLength(255)]
        public string Address { get; set; }

        [Column("gender"), Required]
        public bool Gender { get; set; }

        [Column("must_pay"), Required]
        public bool MustPay { get; set; }

        [Column("active"), Required]
        public bool Active { get; set; }

        public virtual ICollection<FeeLogs> FeeLogs { get; set; }
    }
}
