using System;
using System.Linq;
using System.Linq.Expressions;

namespace FireDeptFeesTool.Model
{
    partial class Member
    {
        /// <summary>
        /// Returns a string of the following format: "VulkanID, Name Surname"
        /// </summary>
        public string SurnameAndNameWithVulkanID
        {
            get { return Surname + " " + Name + ", " + VulkanID; }
        }

        public string NameAndSurname
        {
            get { return Name + " " + Surname; }
        }

        public string NameUpperWOSumniki
        {
            get { return Name.ToUpperInvariant().Replace('Č', 'C').Replace('Š', 'S').Replace('Ž', 'Z'); }
        }

        public string SurnameUpperWOSumniki
        {
            get { return Surname.ToUpperInvariant().Replace('Č', 'C').Replace('Š', 'S').Replace('Ž', 'Z'); }
        }

        public void AddDefaultFeeLogForCurrentYear()
        {
            AddDefaultFeeLogForYear(DateTime.Now.Year);
        }

        public void AddDefaultFeeLogForYear(int year)
        {
            if (!ExistsFeeLogForYear(year))
            {
                FeeLogs.Add(
                    new FeeLogs
                        {
                            Member = this,
                            Year = (short) year,
                            PaymentStatusID = PaymentStatus.NI_PODATKA
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

        public bool Bla()
        {
            return FeeLogs.Where(fl => fl.Year == 2013).Any(fl => fl.PaymentStatusID == PaymentStatus.PLACAL);
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
    }
}