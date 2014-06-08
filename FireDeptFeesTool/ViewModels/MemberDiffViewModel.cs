using System;
using FireDeptFeesTool.Model;

namespace FireDeptFeesTool.ViewModels
{
    internal class MemberDiffViewModel
    {
        public MemberDiffViewModel(Member member, Member newMember)
        {
            if (member != null)
            {
                OldVulkanID = member.VulkanID;
                OldSurname = member.Surname;
                OldName = member.Name;
                OldAddress = member.Address;
                OldDateOfBirth = member.DateOfBirth;
                OldGender = member.Gender ? "M" : "Ž";
            }

            if (newMember != null)
            {
                NewVulkanID = newMember.VulkanID;
                NewSurname = newMember.Surname;
                NewName = newMember.Name;
                NewAddress = newMember.Address;
                NewDateOfBirth = newMember.DateOfBirth;
                NewGender = newMember.Gender ? "M" : "Ž";
            }

            if (member == null && newMember != null)
            {
                Action = "Dodajanje";
            }
            else if (member != null && newMember == null)
            {
                Action = "Brisanje";
            }
            else
            {
                Action = "Posodobitev";
            }
        }

        public string OldVulkanID { get; set; }
        public string OldSurname { get; set; }
        public string OldName { get; set; }
        public string OldAddress { get; set; }
        public DateTime OldDateOfBirth { get; set; }
        public string OldGender { get; set; }

        public string NewVulkanID { get; set; }
        public string NewSurname { get; set; }
        public string NewName { get; set; }
        public string NewAddress { get; set; }
        public DateTime NewDateOfBirth { get; set; }
        public string NewGender { get; set; }

        public string Action { get; set; }
    }
}