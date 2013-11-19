using System;
using System.Windows.Forms;

namespace FireDeptFeesTool.Forms
{
    public partial class SelectYearForm : Form
    {
        public SelectYearForm()
        {
            InitializeComponent();
        }

        public int Year { get; private set; }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Year = dateTimePicker.Value.Year;
        }
    }
}