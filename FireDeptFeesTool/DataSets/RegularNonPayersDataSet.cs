using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireDeptFeesTool.ReportModels;

namespace FireDeptFeesTool.DataSets
{
    public class RegularNonPayersDataSet
    {
        public RegularNonPayersDataSet(List<RegularNonPayersReportModel> list)
        {
            NonPayers = list;
        }

        public List<RegularNonPayersReportModel> NonPayers { get; set; }
    }
}
