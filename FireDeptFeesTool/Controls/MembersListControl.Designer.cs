namespace FireDeptFeesTool.Controls
{
    partial class MembersListControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.importMembersButton = new System.Windows.Forms.Button();
            this.membersDataGridView = new System.Windows.Forms.DataGridView();
            this.additionalDisplayOptionsButton = new System.Windows.Forms.Button();
            this.additionalActionsButton = new System.Windows.Forms.Button();
            this.additionalActionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalDisplayOptionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.onlyMustPayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeDeletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.membersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VulkanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MustPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersDataGridView)).BeginInit();
            this.additionalActionsContextMenuStrip.SuspendLayout();
            this.additionalDisplayOptionsContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.Controls.Add(this.saveChangesButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.importMembersButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.membersDataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.additionalDisplayOptionsButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.additionalActionsButton, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(610, 405);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveChangesButton.Location = new System.Drawing.Point(502, 376);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(105, 23);
            this.saveChangesButton.TabIndex = 2;
            this.saveChangesButton.Text = "Shrani spremembe";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // importMembersButton
            // 
            this.importMembersButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.importMembersButton.Location = new System.Drawing.Point(3, 376);
            this.importMembersButton.Name = "importMembersButton";
            this.importMembersButton.Size = new System.Drawing.Size(74, 23);
            this.importMembersButton.TabIndex = 1;
            this.importMembersButton.Text = "Uvoz...";
            this.importMembersButton.UseVisualStyleBackColor = true;
            this.importMembersButton.Click += new System.EventHandler(this.ImportMembersButton_Click);
            // 
            // membersDataGridView
            // 
            this.membersDataGridView.AllowUserToAddRows = false;
            this.membersDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.membersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.membersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.membersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.membersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.VulkanID,
            this.MemberSurname,
            this.MemberName,
            this.Address,
            this.DateOfBirth,
            this.Gender,
            this.MustPay});
            this.tableLayoutPanel1.SetColumnSpan(this.membersDataGridView, 5);
            this.membersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.membersDataGridView.Location = new System.Drawing.Point(3, 3);
            this.membersDataGridView.Name = "membersDataGridView";
            this.membersDataGridView.RowHeadersWidth = 50;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure;
            this.membersDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.membersDataGridView.Size = new System.Drawing.Size(604, 364);
            this.membersDataGridView.TabIndex = 0;
            this.membersDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.MembersDataGridView_CellValueChanged);
            this.membersDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MembersDataGridView_ColumnHeaderMouseClick);
            this.membersDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.MembersDataGridView_DataBindingComplete);
            this.membersDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.MembersDataGridView_RowPostPaint);
            // 
            // additionalDisplayOptionsButton
            // 
            this.additionalDisplayOptionsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.additionalDisplayOptionsButton.Location = new System.Drawing.Point(83, 376);
            this.additionalDisplayOptionsButton.Name = "additionalDisplayOptionsButton";
            this.additionalDisplayOptionsButton.Size = new System.Drawing.Size(74, 23);
            this.additionalDisplayOptionsButton.TabIndex = 5;
            this.additionalDisplayOptionsButton.Text = "Prikaz";
            this.additionalDisplayOptionsButton.UseVisualStyleBackColor = true;
            this.additionalDisplayOptionsButton.Click += new System.EventHandler(this.AdditionalDisplayOptionsButton_Click);
            // 
            // additionalActionsButton
            // 
            this.additionalActionsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.additionalActionsButton.Location = new System.Drawing.Point(163, 376);
            this.additionalActionsButton.Name = "additionalActionsButton";
            this.additionalActionsButton.Size = new System.Drawing.Size(74, 23);
            this.additionalActionsButton.TabIndex = 6;
            this.additionalActionsButton.Text = "Akcije";
            this.additionalActionsButton.UseVisualStyleBackColor = true;
            this.additionalActionsButton.Click += new System.EventHandler(this.AdditionalActionsButton_Click);
            // 
            // additionalActionsContextMenuStrip
            // 
            this.additionalActionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSelectedToolStripMenuItem,
            this.restoreSelectedToolStripMenuItem});
            this.additionalActionsContextMenuStrip.Name = "additionalActionsContextMenuStrip";
            this.additionalActionsContextMenuStrip.Size = new System.Drawing.Size(150, 48);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Briši izbrane";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.DeleteSelectedToolStripMenuItem_Click);
            // 
            // restoreSelectedToolStripMenuItem
            // 
            this.restoreSelectedToolStripMenuItem.Name = "restoreSelectedToolStripMenuItem";
            this.restoreSelectedToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.restoreSelectedToolStripMenuItem.Text = "Povrni izbrane";
            this.restoreSelectedToolStripMenuItem.Click += new System.EventHandler(this.RestoreSelectedToolStripMenuItem_Click);
            // 
            // additionalDisplayOptionsContextMenuStrip
            // 
            this.additionalDisplayOptionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlyMustPayersToolStripMenuItem,
            this.includeDeletedToolStripMenuItem});
            this.additionalDisplayOptionsContextMenuStrip.Name = "additionalDisplayOptionsContextMenuStrip";
            this.additionalDisplayOptionsContextMenuStrip.Size = new System.Drawing.Size(158, 48);
            // 
            // onlyMustPayersToolStripMenuItem
            // 
            this.onlyMustPayersToolStripMenuItem.CheckOnClick = true;
            this.onlyMustPayersToolStripMenuItem.Name = "onlyMustPayersToolStripMenuItem";
            this.onlyMustPayersToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.onlyMustPayersToolStripMenuItem.Text = "Samo obvezniki";
            this.onlyMustPayersToolStripMenuItem.Click += new System.EventHandler(this.OnlyMustPayersToolStripMenuItem_Click);
            // 
            // includeDeletedToolStripMenuItem
            // 
            this.includeDeletedToolStripMenuItem.CheckOnClick = true;
            this.includeDeletedToolStripMenuItem.Name = "includeDeletedToolStripMenuItem";
            this.includeDeletedToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.includeDeletedToolStripMenuItem.Text = "Tudi brisani";
            this.includeDeletedToolStripMenuItem.Click += new System.EventHandler(this.IncludeDeletedToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "";
            this.Selected.Name = "Selected";
            this.Selected.Width = 5;
            // 
            // VulkanID
            // 
            this.VulkanID.DataPropertyName = "VulkanID";
            this.VulkanID.HeaderText = "Vulkan ID";
            this.VulkanID.Name = "VulkanID";
            this.VulkanID.ReadOnly = true;
            this.VulkanID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.VulkanID.Width = 79;
            // 
            // MemberSurname
            // 
            this.MemberSurname.DataPropertyName = "Surname";
            this.MemberSurname.HeaderText = "Priimek";
            this.MemberSurname.Name = "MemberSurname";
            this.MemberSurname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.MemberSurname.Width = 66;
            // 
            // MemberName
            // 
            this.MemberName.DataPropertyName = "Name";
            this.MemberName.HeaderText = "Ime";
            this.MemberName.Name = "MemberName";
            this.MemberName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.MemberName.Width = 49;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Naslov";
            this.Address.Name = "Address";
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Address.Width = 65;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.DataPropertyName = "DateOfBirth";
            this.DateOfBirth.HeaderText = "Datum rojstva";
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            this.DateOfBirth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DateOfBirth.Width = 97;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Spol";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Gender.Width = 53;
            // 
            // MustPay
            // 
            this.MustPay.DataPropertyName = "MustPay";
            this.MustPay.HeaderText = "Obveznik";
            this.MustPay.Name = "MustPay";
            this.MustPay.ReadOnly = true;
            this.MustPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.MustPay.Width = 77;
            // 
            // MembersListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "MembersListControl";
            this.Size = new System.Drawing.Size(610, 405);
            this.VisibleChanged += new System.EventHandler(this.MembersListControl_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.membersDataGridView)).EndInit();
            this.additionalActionsContextMenuStrip.ResumeLayout(false);
            this.additionalDisplayOptionsContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.Button importMembersButton;
        private System.Windows.Forms.DataGridView membersDataGridView;
        private System.Windows.Forms.Button additionalDisplayOptionsButton;
        private System.Windows.Forms.Button additionalActionsButton;
        private System.Windows.Forms.ContextMenuStrip additionalActionsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreSelectedToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip additionalDisplayOptionsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem onlyMustPayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeDeletedToolStripMenuItem;
        private System.Windows.Forms.BindingSource membersBindingSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn VulkanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn MustPay;

    }
}
