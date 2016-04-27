namespace FireDeptFeesTool.Forms
{
    partial class ImportMembersDiffForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.membersDiffDataGridView = new System.Windows.Forms.DataGridView();
            this.OldVulkanID = new FireDeptFeesTool.Lib.DataGridViewCheckBoxWithLabelColumn();
            this.OldSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewVulkanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxWithLabelColumn1 = new FireDeptFeesTool.Lib.DataGridViewCheckBoxWithLabelColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersDiffDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.membersDiffDataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.confirmButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(811, 481);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmButton.Location = new System.Drawing.Point(654, 452);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(74, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Potrdi";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(734, 452);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(74, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Prekliči";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // membersDiffDataGridView
            // 
            this.membersDiffDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.membersDiffDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OldVulkanID,
            this.OldSurname,
            this.OldName,
            this.OldAddress,
            this.OldDateOfBirth,
            this.OldGender,
            this.NewVulkanID,
            this.NewSurname,
            this.NewName,
            this.NewAddress,
            this.NewDateOfBirth,
            this.NewGender,
            this.Action});
            this.tableLayoutPanel1.SetColumnSpan(this.membersDiffDataGridView, 3);
            this.membersDiffDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.membersDiffDataGridView.Location = new System.Drawing.Point(3, 3);
            this.membersDiffDataGridView.Name = "membersDiffDataGridView";
            this.membersDiffDataGridView.Size = new System.Drawing.Size(805, 440);
            this.membersDiffDataGridView.TabIndex = 0;
            this.membersDiffDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.MembersDiffDataGridView_CellPainting);
            // 
            // OldVulkanID
            // 
            this.OldVulkanID.DataPropertyName = "OldVulkanIDSelected";
            this.OldVulkanID.HeaderText = "OldVulkanID";
            this.OldVulkanID.Label = null;
            this.OldVulkanID.Name = "OldVulkanID";
            this.OldVulkanID.ReadOnly = true;
            this.OldVulkanID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OldVulkanID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // OldSurname
            // 
            this.OldSurname.DataPropertyName = "OldSurname";
            this.OldSurname.HeaderText = "OldSurname";
            this.OldSurname.Name = "OldSurname";
            this.OldSurname.ReadOnly = true;
            this.OldSurname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OldName
            // 
            this.OldName.DataPropertyName = "OldName";
            this.OldName.HeaderText = "OldName";
            this.OldName.Name = "OldName";
            this.OldName.ReadOnly = true;
            // 
            // OldAddress
            // 
            this.OldAddress.DataPropertyName = "OldAddress";
            this.OldAddress.HeaderText = "OldAddress";
            this.OldAddress.Name = "OldAddress";
            this.OldAddress.ReadOnly = true;
            // 
            // OldDateOfBirth
            // 
            this.OldDateOfBirth.DataPropertyName = "OldDateOfBirth";
            this.OldDateOfBirth.HeaderText = "OldDateOfBirth";
            this.OldDateOfBirth.Name = "OldDateOfBirth";
            this.OldDateOfBirth.ReadOnly = true;
            // 
            // OldGender
            // 
            this.OldGender.DataPropertyName = "OldGender";
            this.OldGender.HeaderText = "OldGender";
            this.OldGender.Name = "OldGender";
            this.OldGender.ReadOnly = true;
            // 
            // NewVulkanID
            // 
            this.NewVulkanID.DataPropertyName = "NewVulkanID";
            this.NewVulkanID.HeaderText = "NewVulkanID";
            this.NewVulkanID.Name = "NewVulkanID";
            this.NewVulkanID.ReadOnly = true;
            // 
            // NewSurname
            // 
            this.NewSurname.DataPropertyName = "NewSurname";
            this.NewSurname.HeaderText = "NewSurname";
            this.NewSurname.Name = "NewSurname";
            this.NewSurname.ReadOnly = true;
            // 
            // NewName
            // 
            this.NewName.DataPropertyName = "NewName";
            this.NewName.HeaderText = "NewName";
            this.NewName.Name = "NewName";
            this.NewName.ReadOnly = true;
            // 
            // NewAddress
            // 
            this.NewAddress.DataPropertyName = "NewAddress";
            this.NewAddress.HeaderText = "NewAddress";
            this.NewAddress.Name = "NewAddress";
            this.NewAddress.ReadOnly = true;
            // 
            // NewDateOfBirth
            // 
            this.NewDateOfBirth.DataPropertyName = "NewDateOfBirth";
            this.NewDateOfBirth.HeaderText = "NewDateOfBirth";
            this.NewDateOfBirth.Name = "NewDateOfBirth";
            this.NewDateOfBirth.ReadOnly = true;
            // 
            // NewGender
            // 
            this.NewGender.DataPropertyName = "NewGender";
            this.NewGender.HeaderText = "NewGender";
            this.NewGender.Name = "NewGender";
            this.NewGender.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.DataPropertyName = "Action";
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // dataGridViewCheckBoxWithLabelColumn1
            // 
            this.dataGridViewCheckBoxWithLabelColumn1.DataPropertyName = "OldSurname";
            this.dataGridViewCheckBoxWithLabelColumn1.HeaderText = "OldSurname";
            this.dataGridViewCheckBoxWithLabelColumn1.Label = null;
            this.dataGridViewCheckBoxWithLabelColumn1.Name = "dataGridViewCheckBoxWithLabelColumn1";
            this.dataGridViewCheckBoxWithLabelColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxWithLabelColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxWithLabelColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ImportMembersDiffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImportMembersDiffForm";
            this.Text = "ImportMembersDiffForm";
            this.Load += new System.EventHandler(this.ImportMembersDiffForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.membersDiffDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView membersDiffDataGridView;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private Lib.DataGridViewCheckBoxWithLabelColumn dataGridViewCheckBoxWithLabelColumn1;
        private Lib.DataGridViewCheckBoxWithLabelColumn OldVulkanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewVulkanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;

    }
}