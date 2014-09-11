using System.Collections.Generic;
using FireDeptFeesTool.Model;
using FireDeptFeesTool.ReportModels;
using FireDeptFeesTool.ViewModels;

namespace FireDeptFeesTool.DataSets
{
    public class MemberStickersDataSet
    {
        public MemberStickersDataSet(List<Member> list)
        {
            Members = list;
        }

        public List<Member> Members { get; set; }
    }
}