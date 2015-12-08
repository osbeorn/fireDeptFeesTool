using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDeptFeesTool.Model.Report
{
    public class RegularNonPayersReportModel
    {
        public string VulkanID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Count { get; set; }
        public int Year { get; set; }
        public string Years { get; set; }
    }
}
