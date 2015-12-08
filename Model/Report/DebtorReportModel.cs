using System;
using System.Collections.Generic;
using System.Linq;

namespace FireDeptFeesTool.Model.Report
{
    public class DebtorReportModel
    {
        public string RepDefinition { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<short> YearsList { private get; set; }
        public Decimal DebtSum { get; set; }

        public string YearsNoun
        {
            get { return GetCorrectYearNoun(YearsList); }
        }

        public string Years
        {
            get { return GetStringFromYearsList(YearsList); }
        }


        public string FirstAndLastName
        {
            get { return FirstName + " " + LastName; }
        }

        public string LastAndFirstName
        {
            get { return LastName + " " + FirstName; }
        }

        private string GetCorrectYearNoun(IList<short> list)
        {
            switch (list.Count)
            {
                case 1:
                    return "leto";
                case 2:
                    return "leti";
                default:
                    return "leta";
            }
        }

        private string GetStringFromYearsList(IList<short> list)
        {
            switch (list.Count)
            {
                case 1:
                    return list[0].ToString();
                case 2:
                    return string.Join(" ", list[0], "in", list[1]);
                default:
                    return string.Join(" ",
                                       string.Join(", ", list.Select(l => l.ToString()).ToArray<string>(), 0, list.Count - 1),
                                       "in", list.Last());
            }
        }
    }
}