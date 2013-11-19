using System;
using System.Windows.Forms;
using FireDeptFeesTool.Controls;
using FireDeptFeesTool.Enums;

namespace FireDeptFeesTool.Forms.UPNDocsList
{
    public partial class PrintSelectionForm : Form
    {
        private BillsListControl parent;
        /*
        public PrintSelectionForm(CurrentPaymentsForm parent, bool printAll)
        {
            InitializeComponent();
            CustomInitialization(parent);
            InitializePrintSelectionGroup(printAll);
            InitializePaperTypeSelectionGroup();
        }
        */

        public PrintSelectionForm(BillsListControl parent, bool printAll)
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
                parent.printType = PrintType.Laser;
            }
            else
            {
                parent.printType = PrintType.Endless;
            }
        }
    }
}