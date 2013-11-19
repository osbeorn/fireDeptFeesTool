using System.Collections.Generic;
using System.Windows.Forms;
using FireDeptFeesTool.Forms;

namespace FireDeptFeesTool.Controls
{
    public partial class IListControl : UserControl
    {
        public IListControl()
        {
            InitializeComponent();
        }

        public IListControl(ShellForm container)
        {
            ContainerForm = container;
            InitializeComponent();
        }

        public ShellForm ContainerForm { get; set; }

        public bool FirstClearingOfSelectedRows { get; set; }
        public bool RefreshOnNextLoad { get; set; }
        public List<string> DependantControls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BindData(bool overrideDefaultFlow)
        {
        }

        /// <summary>
        /// Save changes made on the UserControl
        /// </summary>
        public virtual void SaveChanges(bool notifyUser)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnClosing()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        public virtual void ClearSelection(DataGridView dgv)
        {
            dgv.CurrentCell = null;
            dgv.ClearSelection();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void NotifyDependantControlsOfChanges()
        {
            if (DependantControls == null) return;

            foreach (string dependantControl in DependantControls)
            {
                ContainerForm.controlsDict[dependantControl].RefreshOnNextLoad = true;
            }
        }
    }
}