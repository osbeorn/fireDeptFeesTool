namespace FireDeptFeesTool.Controls
{
    partial class PaymentsListControl
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.addOptionButtonContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addCurrentYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSpecificYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importPaymentsHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBankDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printButtonContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printPaymentsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalDisplayOptionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.onlyMustPayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeDeletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.paymentsDataGridView = new System.Windows.Forms.DataGridView();
            this.addOptionButton = new System.Windows.Forms.Button();
            this.importPaymentDataButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.additionalDisplayOptionsButton = new System.Windows.Forms.Button();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VulkanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addOptionButtonContextMenuStrip.SuspendLayout();
            this.importDataContextMenuStrip.SuspendLayout();
            this.printButtonContextMenuStrip.SuspendLayout();
            this.additionalDisplayOptionsContextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // addOptionButtonContextMenuStrip
            // 
            this.addOptionButtonContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.addOptionButtonContextMenuStrip.Name = "addOptionButtonContextMenuStrip";
            this.addOptionButtonContextMenuStrip.Size = new System.Drawing.Size(114, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCurrentYearToolStripMenuItem,
            this.addSpecificYearToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem1.Text = "Stolpec";
            // 
            // addCurrentYearToolStripMenuItem
            // 
            this.addCurrentYearToolStripMenuItem.Name = "addCurrentYearToolStripMenuItem";
            this.addCurrentYearToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addCurrentYearToolStripMenuItem.Text = "Tekoče leto";
            this.addCurrentYearToolStripMenuItem.Click += new System.EventHandler(this.AddCurrentYearToolStripMenuItem_Click);
            // 
            // addSpecificYearToolStripMenuItem
            // 
            this.addSpecificYearToolStripMenuItem.Name = "addSpecificYearToolStripMenuItem";
            this.addSpecificYearToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addSpecificYearToolStripMenuItem.Text = "Poljubno leto...";
            this.addSpecificYearToolStripMenuItem.Click += new System.EventHandler(this.AddSpecificYearToolStripMenuItem_Click);
            // 
            // importDataContextMenuStrip
            // 
            this.importDataContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPaymentsHistoryToolStripMenuItem,
            this.importBankDataToolStripMenuItem});
            this.importDataContextMenuStrip.Name = "contextMenuStrip1";
            this.importDataContextMenuStrip.Size = new System.Drawing.Size(170, 48);
            // 
            // importPaymentsHistoryToolStripMenuItem
            // 
            this.importPaymentsHistoryToolStripMenuItem.Name = "importPaymentsHistoryToolStripMenuItem";
            this.importPaymentsHistoryToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.importPaymentsHistoryToolStripMenuItem.Text = "Seznam članarin...";
            this.importPaymentsHistoryToolStripMenuItem.Click += new System.EventHandler(this.ImportPaymentsHistoryToolStripMenuItem_Click);
            // 
            // importBankDataToolStripMenuItem
            // 
            this.importBankDataToolStripMenuItem.Name = "importBankDataToolStripMenuItem";
            this.importBankDataToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.importBankDataToolStripMenuItem.Text = "Iz izpiskov...";
            this.importBankDataToolStripMenuItem.Click += new System.EventHandler(this.ImportBankDataToolStripMenuItem_Click);
            // 
            // printButtonContextMenuStrip
            // 
            this.printButtonContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printPaymentsListToolStripMenuItem});
            this.printButtonContextMenuStrip.Name = "printButtonContextMenuStrip";
            this.printButtonContextMenuStrip.Size = new System.Drawing.Size(116, 26);
            // 
            // printPaymentsListToolStripMenuItem
            // 
            this.printPaymentsListToolStripMenuItem.Name = "printPaymentsListToolStripMenuItem";
            this.printPaymentsListToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.printPaymentsListToolStripMenuItem.Text = "Seznam";
            this.printPaymentsListToolStripMenuItem.Click += new System.EventHandler(this.PrintPaymentsListToolStripMenuItem_Click);
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
            this.onlyMustPayersToolStripMenuItem.Checked = true;
            this.onlyMustPayersToolStripMenuItem.CheckOnClick = true;
            this.onlyMustPayersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.Controls.Add(this.saveChangesButton, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.paymentsDataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addOptionButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.importPaymentDataButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.printButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.additionalDisplayOptionsButton, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(749, 476);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveChangesButton.BackColor = System.Drawing.SystemColors.Control;
            this.saveChangesButton.Location = new System.Drawing.Point(641, 447);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(105, 23);
            this.saveChangesButton.TabIndex = 0;
            this.saveChangesButton.Text = "Shrani spremembe";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // paymentsDataGridView
            // 
            this.paymentsDataGridView.AllowUserToAddRows = false;
            this.paymentsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.paymentsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.paymentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Active,
            this.VulkanID,
            this.MemberSurname,
            this.MemberName,
            this.DateOfBirth});
            this.tableLayoutPanel1.SetColumnSpan(this.paymentsDataGridView, 6);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.paymentsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.paymentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.paymentsDataGridView.Name = "paymentsDataGridView";
            this.paymentsDataGridView.RowHeadersWidth = 50;
            this.paymentsDataGridView.Size = new System.Drawing.Size(743, 435);
            this.paymentsDataGridView.TabIndex = 3;
            this.paymentsDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.PaymentsDataGridView_CellPainting);
            this.paymentsDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PaymentsDataGridView_CellValueChanged);
            this.paymentsDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.PaymentsDataGridView_DataBindingComplete);
            this.paymentsDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.PaymentsDataGridView_RowPostPaint);
            // 
            // addOptionButton
            // 
            this.addOptionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addOptionButton.Location = new System.Drawing.Point(83, 447);
            this.addOptionButton.Name = "addOptionButton";
            this.addOptionButton.Size = new System.Drawing.Size(74, 23);
            this.addOptionButton.TabIndex = 4;
            this.addOptionButton.Text = "Dodaj";
            this.addOptionButton.UseVisualStyleBackColor = true;
            this.addOptionButton.Click += new System.EventHandler(this.AddOptionButton_Click);
            // 
            // importPaymentDataButton
            // 
            this.importPaymentDataButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.importPaymentDataButton.Location = new System.Drawing.Point(3, 447);
            this.importPaymentDataButton.Name = "importPaymentDataButton";
            this.importPaymentDataButton.Size = new System.Drawing.Size(74, 23);
            this.importPaymentDataButton.TabIndex = 2;
            this.importPaymentDataButton.Text = "Uvoz";
            this.importPaymentDataButton.UseVisualStyleBackColor = true;
            this.importPaymentDataButton.Click += new System.EventHandler(this.ImportPaymentDataButton_Click);
            // 
            // printButton
            // 
            this.printButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.printButton.Location = new System.Drawing.Point(243, 447);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(74, 23);
            this.printButton.TabIndex = 5;
            this.printButton.Text = "Tiskaj";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // additionalDisplayOptionsButton
            // 
            this.additionalDisplayOptionsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.additionalDisplayOptionsButton.Location = new System.Drawing.Point(163, 447);
            this.additionalDisplayOptionsButton.Name = "additionalDisplayOptionsButton";
            this.additionalDisplayOptionsButton.Size = new System.Drawing.Size(74, 23);
            this.additionalDisplayOptionsButton.TabIndex = 6;
            this.additionalDisplayOptionsButton.Text = "Prikaz";
            this.additionalDisplayOptionsButton.UseVisualStyleBackColor = true;
            this.additionalDisplayOptionsButton.Click += new System.EventHandler(this.AdditionalDisplayOptionsButton_Click);
            // 
            // Active
            // 
            this.Active.DataPropertyName = "MemberActive";
            this.Active.Frozen = true;
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Visible = false;
            // 
            // VulkanID
            // 
            this.VulkanID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VulkanID.DataPropertyName = "MemberVulkanID";
            this.VulkanID.Frozen = true;
            this.VulkanID.HeaderText = "Vulkan ID";
            this.VulkanID.Name = "VulkanID";
            this.VulkanID.Width = 79;
            // 
            // MemberSurname
            // 
            this.MemberSurname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemberSurname.DataPropertyName = "MemberSurname";
            this.MemberSurname.Frozen = true;
            this.MemberSurname.HeaderText = "Priimek";
            this.MemberSurname.Name = "MemberSurname";
            this.MemberSurname.ReadOnly = true;
            this.MemberSurname.Width = 66;
            // 
            // MemberName
            // 
            this.MemberName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemberName.DataPropertyName = "MemberName";
            this.MemberName.Frozen = true;
            this.MemberName.HeaderText = "Ime";
            this.MemberName.Name = "MemberName";
            this.MemberName.ReadOnly = true;
            this.MemberName.Width = 49;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateOfBirth.DataPropertyName = "OldDateOfBirth";
            this.DateOfBirth.Frozen = true;
            this.DateOfBirth.HeaderText = "Datum rojstva";
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            this.DateOfBirth.Width = 97;
            // 
            // PaymentsListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "PaymentsListControl";
            this.Size = new System.Drawing.Size(749, 476);
            this.VisibleChanged += new System.EventHandler(this.PaymentsListControl_VisibleChanged);
            this.addOptionButtonContextMenuStrip.ResumeLayout(false);
            this.importDataContextMenuStrip.ResumeLayout(false);
            this.printButtonContextMenuStrip.ResumeLayout(false);
            this.additionalDisplayOptionsContextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paymentsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.DataGridView paymentsDataGridView;
        private System.Windows.Forms.Button addOptionButton;
        private System.Windows.Forms.Button importPaymentDataButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip addOptionButtonContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addCurrentYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSpecificYearToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip importDataContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem importPaymentsHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBankDataToolStripMenuItem;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.ContextMenuStrip printButtonContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem printPaymentsListToolStripMenuItem;
        private System.Windows.Forms.Button additionalDisplayOptionsButton;
        private System.Windows.Forms.ContextMenuStrip additionalDisplayOptionsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem onlyMustPayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeDeletedToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn VulkanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
    }
}
