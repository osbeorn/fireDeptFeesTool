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

                FinalVulkanId = newMember.VulkanID;
                FinalSurname = newMember.Surname;
                FinalName = newMember.Name;
                FinalAddress = newMember.Address;
                FinalDateOfBirth = newMember.DateOfBirth;
                FinalGender = newMember.Gender;
            }
            else if (member != null && newMember == null)
            {
                Action = "Brisanje";
            }
            else if (member != null && newMember != null)
            {
                Action = member.Equals(newMember) ? "Ni sprememb" : "Posodobitev";
            }
        }

        public string OldVulkanID { get; set; }
        public bool OldVulkanIDSelected { get; set; }

        public string OldSurname { get; set; }
        public bool OldSurnameSelected { get; set; }

        public string OldName { get; set; }
        public bool OldNameSelected { get; set; }

        public string OldAddress { get; set; }
        public bool OldAddressSelected { get; set; }

        public DateTime OldDateOfBirth { get; set; }
        public bool OldDateOfBirthSelected { get; set; }

        public string OldGender { get; set; }
        public bool OldGenderSelected { get; set; }


        public string NewVulkanID { get; set; }
        public bool NewVulkanIDSelected { get; set; }

        public string NewSurname { get; set; }
        public bool NewSurnameSelected { get; set; }

        public string NewName { get; set; }
        public bool NewNameSelected { get; set; }

        public string NewAddress { get; set; }
        public bool NewAddressSelected { get; set; }

        public DateTime NewDateOfBirth { get; set; }
        public bool NewDateOfBirthSelected { get; set; }

        public string NewGender { get; set; }
        public bool NewGenderSelected { get; set; }


        public string Action { get; set; }

        // used to store the final data - the user has to decide
        // which data will be final; old one or the new one
        public string FinalVulkanId { get; set; }
        public string FinalSurname { get; set; }
        public string FinalName { get; set; }
        public string FinalAddress { get; set; }
        public DateTime FinalDateOfBirth { get; set; }
        public bool FinalGender { get; set; }
    }

    public enum MemberDiffViewAction
    {
        ADD,
        DELETE,
        NO_CHANGNE,
        UPDATE
    }
}