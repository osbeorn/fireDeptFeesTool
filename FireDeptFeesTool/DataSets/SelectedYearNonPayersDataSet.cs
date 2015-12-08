using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireDeptFeesTool.Model.Report;

namespace FireDeptFeesTool.DataSets
{
    public class SelectedYearNonPayersDataSet
    {
        public SelectedYearNonPayersDataSet(List<SelectedYearNonPayersReportModel> list)
        {
            NonPayers = list;
        }

        public List<SelectedYearNonPayersReportModel> NonPayers { get; set; }
    }
}
