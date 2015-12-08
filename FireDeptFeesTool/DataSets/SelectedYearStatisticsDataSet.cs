using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireDeptFeesTool.Model.Report;

namespace FireDeptFeesTool.DataSets
{
    public class SelectedYearStatisticsDataSet
    {
        public SelectedYearStatisticsDataSet(List<SelectedYearStatisticsReportModel> list)
        {
            PaymentsStatusIDs = list;
        }

        public List<SelectedYearStatisticsReportModel> PaymentsStatusIDs { get; set; }
    }
}
