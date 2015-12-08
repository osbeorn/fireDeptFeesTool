using System;
using FireDeptFeesTool.Model.Main;

namespace FireDeptFeesTool.Model.View
{
    public class MemberViewModel
    {
        public MemberViewModel()
        {
        }

        public MemberViewModel(
            bool selected,
            string vulkanID,
            string surname,
            string name,
            string address,
            DateTime dateOfBirth,
            string gender,
            string mustPay,
            bool active
            )
        {
            Selected = selected;
            VulkanID = vulkanID;
            Surname = surname;
            Name = name;
            Address = address;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            MustPay = mustPay;
            Active = active;
        }

        public bool Selected { get; set; }
        public string VulkanID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MustPay { get; set; }
        public bool Active { get; set; }

        public Member ToDBMember()
        {
            return new Member
                       {
                           VulkanID = VulkanID,
                           Name = Name,
                           Surname = Surname,
                           Address = Address,
                           DateOfBirth = DateOfBirth,
                           Gender = Gender.Equals("M") ? true : false,
                           MustPay = MustPay.Equals("DA") ? true : false,
                           Active = Active
                       };
        }
    }
}