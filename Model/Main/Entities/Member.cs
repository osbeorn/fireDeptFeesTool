using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireDeptFeesTool.Model.Main
{
    [Table("member")]
    public partial class Member
    {
        public Member()
        {
            this.FeeLogs = new HashSet<FeeLogs>();
        }

        [Key]
        [MinLength(6), MaxLength(6)]
        public string VulkanID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        [Required]
        public System.DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public bool MustPay { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ICollection<FeeLogs> FeeLogs { get; set; }
    }
}
