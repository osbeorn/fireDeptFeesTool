using System;
using System.Linq;
using System.Linq.Expressions;

namespace FireDeptFeesTool.Model.Main
{
    partial class Member
    {
        /// <summary>
        /// Returns a string of the following format: "OldVulkanID, OldName OldSurname"
        /// </summary>
        public string SurnameAndNameWithVulkanID
        {
            get
            {
                return 
                    (Surname != null && Name != null && VulkanID != null)
                    ? Surname + " " + Name + ", " + VulkanID
                    : "";
            }
        }

        public string NameAndSurname
        {
            get
            {
                return 
                    (Name != null && Surname != null)
                    ? Name + " " + Surname
                    : "";
            }
        }

        public string NameUpperWOSumniki
        {
            get
            {
                return 
                    Name != null
                    ? Name.ToUpperInvariant().Replace('Č', 'C').Replace('Š', 'S').Replace('Ž', 'Z')
                    : "";
            }
        }

        public string SurnameUpperWOSumniki
        {
            get
            {
                return
                    Surname != null
                    ? Surname.ToUpperInvariant().Replace('Č', 'C').Replace('Š', 'S').Replace('Ž', 'Z')
                    : "";
            }
        }

        public string StreetAddress
        {
            get
            {
                return 
                    Address != null
                    ? Address.Split(',')[0].Trim()
                    : "";
            }
        }

        public string PostOffice
        {
            get
            {
                return 
                    Address != null
                    ? Address.Split(',')[1].Trim()
                    : "";
            }
        }

        public void AddDefaultFeeLogForCurrentYear(decimal mensFee, decimal womensFee)
        {
            AddDefaultFeeLogForYear(DateTime.Now.Year, mensFee, womensFee);
        }

        public void AddDefaultFeeLogForYear(int year, decimal mensFee, decimal womensFee)
        {
            if (!ExistsFeeLogForYear(year))
            {
                FeeLogs.Add(
                    new FeeLogs
                        {
                            Member = this,
                            Year = (short) year,
                            PaymentStatus = PaymentStatusEnum.NI_PLACAL,
                            FeeToPay =
                                this.Gender
                                ? mensFee//ConfigHelper.GetConfigValue<decimal>(ConfigFields.ZNESEK_CLANI)
                                : womensFee//ConfigHelper.GetConfigValue<decimal>(ConfigFields.ZNESEK_CLANICE),
                        }
                    );
            }
        }

        public bool ExistsFeeLogForCurrentYear()
        {
            return ExistsFeeLogForYear(DateTime.Now.Year);
        }

        public bool ExistsFeeLogForYear(int year)
        {
            using (var db = new FeeStatusesDBContext())
            {
                return FeeLogs.Any(fl => fl.Year == (short) year);
            }
        }

        public int GetMemberAgeForCurrentYear()
        {
            return GetMemberAgeForYear(DateTime.Now.Year);
        }

        public int GetMemberAgeForYear(int year)
        {
            return year - DateOfBirth.Year;
        }

        public Expression<Func<string, bool>> NameAndSurnameMatchInput(string fullName)
        {
            string tmpName = Name.ToUpperInvariant().Replace('Č', 'C').Replace('Š', 'S').Replace('Ž', 'Z');
            string tmpSurname = Surname.ToUpperInvariant().Replace('Č', 'C').Replace('Š', 'S').Replace('Ž', 'Z');

            return s =>
                   fullName.Equals(tmpName + " " + tmpSurname) ||
                   fullName.Equals(tmpSurname + " " + tmpName);
        }

        public override bool Equals(object obj)
        {
            var m = obj as Member;

            if (m == null)
            {
                return false;
            }

            return Equals(m);
        }

        public bool Equals(Member m)
        {
            return
                VulkanID == m.VulkanID &&
                Name == m.Name &&
                Surname == m.Surname &&
                Address == m.Address &&
                DateOfBirth == m.DateOfBirth &&
                Gender == m.Gender;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}