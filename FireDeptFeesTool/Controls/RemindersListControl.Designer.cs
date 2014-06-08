namespace FireDeptFeesTool.Controls
{
    partial class RemindersListControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentDebtsDataGridView = new System.Windows.Forms.DataGridView();
            this.MemberVulkanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberSurnameAndName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.yearFromComboBox = new System.Windows.Forms.ComboBox();
            this.yearToComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PrepareRemindersButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDebtsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.paymentDebtsDataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.printButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.yearFromComboBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.yearToComboBox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.PrepareRemindersButton, 6, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 403);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // paymentDebtsDataGridView
            // 
            this.paymentDebtsDataGridView.AllowUserToAddRows = false;
            this.paymentDebtsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this.paymentDebtsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.paymentDebtsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.paymentDebtsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentDebtsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemberVulkanID,
            this.MemberSurnameAndName});
            this.tableLayoutPanel1.SetColumnSpan(this.paymentDebtsDataGridView, 7);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.paymentDebtsDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.paymentDebtsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentDebtsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.paymentDebtsDataGridView.Name = "paymentDebtsDataGridView";
            this.paymentDebtsDataGridView.RowHeadersWidth = 50;
            this.paymentDebtsDataGridView.Size = new System.Drawing.Size(726, 362);
            this.paymentDebtsDataGridView.TabIndex = 0;
            this.paymentDebtsDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.PaymentDebtsDataGridView_RowPostPaint);
            // 
            // MemberVulkanID
            // 
            this.MemberVulkanID.DataPropertyName = "MemberVulkanID";
            this.MemberVulkanID.HeaderText = "OldVulkanID";
            this.MemberVulkanID.Name = "MemberVulkanID";
            this.MemberVulkanID.ReadOnly = true;
            this.MemberVulkanID.Visible = false;
            this.MemberVulkanID.Width = 76;
            // 
            // MemberSurnameAndName
            // 
            this.MemberSurnameAndName.DataPropertyName = "MemberSurnameAndName";
            this.MemberSurnameAndName.HeaderText = "Priimek in ime";
            this.MemberSurnameAndName.Name = "MemberSurnameAndName";
            this.MemberSurnameAndName.ReadOnly = true;
            this.MemberSurnameAndName.Width = 96;
            // 
            // printButton
            // 
            this.printButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.printButton.Location = new System.Drawing.Point(3, 374);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(74, 23);
            this.printButton.TabIndex = 2;
            this.printButton.Text = "Tiskaj...";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Obdobje:";
            // 
            // yearFromComboBox
            // 
            this.yearFromComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.yearFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearFromComboBox.FormattingEnabled = true;
            this.yearFromComboBox.Location = new System.Drawing.Point(143, 375);
            this.yearFromComboBox.Name = "yearFromComboBox";
            this.yearFromComboBox.Size = new System.Drawing.Size(49, 21);
            this.yearFromComboBox.TabIndex = 4;
            this.yearFromComboBox.SelectedIndexChanged += new System.EventHandler(this.YearFromComboBox_SelectedIndexChanged);
            // 
            // yearToComboBox
            // 
            this.yearToComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.yearToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearToComboBox.FormattingEnabled = true;
            this.yearToComboBox.Location = new System.Drawing.Point(212, 375);
            this.yearToComboBox.Name = "yearToComboBox";
            this.yearToComboBox.Size = new System.Drawing.Size(49, 21);
            this.yearToComboBox.TabIndex = 5;
            this.yearToComboBox.SelectedIndexChanged += new System.EventHandler(this.YearToComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "-";
            // 
            // PrepareRemindersButton
            // 
            this.PrepareRemindersButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrepareRemindersButton.Location = new System.Drawing.Point(655, 374);
            this.PrepareRemindersButton.Name = "PrepareRemindersButton";
            this.PrepareRemindersButton.Size = new System.Drawing.Size(74, 23);
            this.PrepareRemindersButton.TabIndex = 7;
            this.PrepareRemindersButton.Text = "Pripravi";
            this.PrepareRemindersButton.UseVisualStyleBackColor = true;
            this.PrepareRemindersButton.Click += new System.EventHandler(this.PrepareRemindersButton_Click);
            // 
            // RemindersListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "RemindersListControl";
            this.Size = new System.Drawing.Size(732, 403);
            this.VisibleChanged += new System.EventHandler(this.RemindersListControl_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDebtsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView paymentDebtsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberVulkanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberSurnameAndName;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox yearFromComboBox;
        private System.Windows.Forms.ComboBox yearToComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PrepareRemindersButton;
    }
}
