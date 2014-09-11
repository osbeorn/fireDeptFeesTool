using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireDeptFeesTool.Forms
{
    public partial class SelectYearRange : Form
    {
        public List<int> Years { get; private set; } 

        public SelectYearRange(List<int> allYears)
        {
            InitializeComponent();
            FillYearsListBox(allYears);
        }

        private void FillYearsListBox(List<int> allYears)
        {
            foreach (var year in allYears)
            {
                yearsListBox.Items.Add(year);
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            Years = yearsListBox.SelectedItems.Cast<int>().ToList();
        }
    }
}
