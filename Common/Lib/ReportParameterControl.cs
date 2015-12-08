using System;
using System.Windows.Forms;

namespace FireDeptFeesTool.Common.Lib
{
    public class ReportParameterControl
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public Control Control { get; set; }
        public Type ParameterType { get; set; }
    }
}