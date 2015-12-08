using System;
using System.Windows.Forms;
using FireDeptFeesTool.Controls;
using FireDeptFeesTool.Common.Enums;

namespace FireDeptFeesTool.Forms.UPNDocsList
{
    public partial class PrintFormsSelectionForm : Form
    {
        private BillsListControl parent;
        /*
        public PrintStickersSelectionForm(CurrentPaymentsForm parent, bool printAll)
        {
            InitializeComponent();
            CustomInitialization(parent);
            InitializePrintSelectionGroup(printAll);
            InitializePaperTypeSelectionGroup();
        }
        */

        public PrintFormsSelectionForm(BillsListControl parent, bool printAll)
        {
            InitializeComponent();
            CustomInitialization(parent);
            InitializePrintSelectionGroup(printAll);
            InitializePaperTypeSelectionGroup();
        }

        private void CustomInitialization(BillsListControl parent)
        {
            this.parent = parent;
            parent.rowsPrinted = 0;
        }

        private void InitializePrintSelectionGroup(bool printAll)
        {
            if (printAll)
            {
                printAllRadioButton.Checked = true;
            }
            else
            {
                printSelectionRadioButton.Checked = true;
            }
        }

        private void InitializePaperTypeSelectionGroup()
        {
            laserPaperRadioButton.Checked = true;
        }

        private void PrintAllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
            {
                parent.printAll = true;
            }
            else
            {
                parent.printAll = false;
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            parent.dueDate = dueDateDateTimePicker.Value;
        }

        private void LaserPaperRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
            {
                parent.paperType = PaperType.Laser;
            }
            else
            {
                parent.paperType = PaperType.Endless;
            }
        }
    }
}