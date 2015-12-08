using System.Collections.Generic;
using FireDeptFeesTool.Model.Main;
using FireDeptFeesTool.Model.Report;
using FireDeptFeesTool.Model.View;

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