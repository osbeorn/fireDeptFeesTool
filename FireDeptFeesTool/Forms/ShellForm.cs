using System.Collections.Generic;
using System.Windows.Forms;
using FireDeptFeesTool.Controls;

namespace FireDeptFeesTool.Forms
{
    public partial class ShellForm : Form
    {
        private TabPage _previousTab;
        public Dictionary<string, IListControl> controlsDict;

        public ShellForm()
        {
            InitializeComponent();
            InitializeTabPages();
        }

        private void InitializeTabPages()
        {
            IListControl tempControl;
            controlsDict = new Dictionary<string, IListControl>();

            #region membersTabPage

            tempControl = new MembersListControl(this);

            tabControl.TabPages["membersTabPage"].Controls.Add(tempControl);
            tabControl.TabPages["membersTabPage"].Controls[0].Dock = DockStyle.Fill;

            controlsDict.Add("MembersListControl", tempControl);

            #endregion membersTabPage

            #region paymentsTabPage

            tempControl = new PaymentsListControl(this);

            tabControl.TabPages["paymentsTabPage"].Controls.Add(tempControl);
            tabControl.TabPages["paymentsTabPage"].Controls[0].Dock = DockStyle.Fill;

            controlsDict.Add("PaymentsListControl", tempControl);

            #endregion paymentsTabPage

            #region billsTabPage

            tempControl = new BillsListControl(this);

            tabControl.TabPages["billsTabPage"].Controls.Add(tempControl);
            tabControl.TabPages["billsTabPage"].Controls[0].Dock = DockStyle.Fill;

            controlsDict.Add("BillsListControl", tempControl);

            #endregion billsTabPage

            #region remindersTabPage

            tempControl = new RemindersListControl(this);

            tabControl.TabPages["remindersTabPage"].Controls.Add(tempControl);
            tabControl.TabPages["remindersTabPage"].Controls[0].Dock = DockStyle.Fill;

            controlsDict.Add("RemindersListControl", tempControl);

            #endregion remindersTabPage
        }

        private void TabControl1_Deselected(object sender, TabControlEventArgs e)
        {
            _previousTab = e.TabPage;
        }

        private void ShellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TabPage activeTab = tabControl.SelectedTab;
            var activeControl = activeTab.Controls[0] as IListControl;

            if (activeControl != null)
                activeControl.OnClosing();
        }

        #region Event handlers

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            bool? dataChanged = null;

            var srcControl = _previousTab.Controls[0] as IListControl;

            TabPage targetTab = ((TabControl) sender).SelectedTab;
            var dstControl = targetTab.Controls[0] as IListControl;

            if (srcControl == null || dstControl == null) return;

            switch (_previousTab.Tag as string)
            {
                case "0": // membersTabPage
                    dataChanged = ((MembersListControl) srcControl).DataChanged;
                    break;
                case "1": // paymentsTabPage
                    dataChanged = ((PaymentsListControl) srcControl).DataChanged;
                    break;
                case "2": // billsTabPage
                    break;
                case "3": // remindersTabPage
                    break;
            }

            if (dataChanged.HasValue && dataChanged.Value)
            {
                srcControl.SaveChanges(true);
            }
            dstControl.BindData(false);
        }

        private void OpenSettingsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new ManageSettingsForm().ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void AboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        #endregion Event handlers
    }
}