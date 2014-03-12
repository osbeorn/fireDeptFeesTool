namespace FireDeptFeesTool.Forms
{
    partial class SelectBankExportDocumentsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BankDocData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Years = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warning = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.finishImportButton = new System.Windows.Forms.Button();
            this.cancelImportButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.finishImportButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cancelImportButton, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(640, 384);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.BankDocData,
            this.Member,
            this.Years,
            this.Warning});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.Size = new System.Drawing.Size(634, 343);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridView1_EditingControlShowing);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridView1_RowPostPaint);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataGridView1_RowPrePaint);
            this.dataGridView1.VisibleChanged += new System.EventHandler(this.DataGridView1_VisibleChanged);
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "";
            this.Selected.Name = "Selected";
            this.Selected.Width = 5;
            // 
            // BankDocData
            // 
            this.BankDocData.DataPropertyName = "BankDocData";
            this.BankDocData.HeaderText = "Naziv plačnika, namen in znesek";
            this.BankDocData.Name = "BankDocData";
            this.BankDocData.ReadOnly = true;
            this.BankDocData.Width = 128;
            // 
            // Member
            // 
            this.Member.DataPropertyName = "Member";
            this.Member.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Member.HeaderText = "Član";
            this.Member.Name = "Member";
            this.Member.Width = 34;
            // 
            // Years
            // 
            this.Years.DataPropertyName = "Years";
            this.Years.HeaderText = "Leto/Leta";
            this.Years.Name = "Years";
            this.Years.Width = 79;
            // 
            // Warning
            // 
            this.Warning.DataPropertyName = "Warning";
            this.Warning.HeaderText = "Opozorilo";
            this.Warning.Name = "Warning";
            this.Warning.ReadOnly = true;
            this.Warning.Visible = false;
            this.Warning.Width = 57;
            // 
            // finishImportButton
            // 
            this.finishImportButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.finishImportButton.Location = new System.Drawing.Point(483, 355);
            this.finishImportButton.Name = "finishImportButton";
            this.finishImportButton.Size = new System.Drawing.Size(74, 23);
            this.finishImportButton.TabIndex = 1;
            this.finishImportButton.Text = "Dokončaj";
            this.finishImportButton.UseVisualStyleBackColor = true;
            this.finishImportButton.Click += new System.EventHandler(this.FinishImportButton_Click);
            // 
            // cancelImportButton
            // 
            this.cancelImportButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelImportButton.Location = new System.Drawing.Point(563, 355);
            this.cancelImportButton.Name = "cancelImportButton";
            this.cancelImportButton.Size = new System.Drawing.Size(74, 23);
            this.cancelImportButton.TabIndex = 2;
            this.cancelImportButton.Text = "Prekini";
            this.cancelImportButton.UseVisualStyleBackColor = true;
            this.cancelImportButton.Click += new System.EventHandler(this.CancelImportButton_Click);
            // 
            // SelectBankExportDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 384);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SelectBankExportDocumentsForm";
            this.Text = "Uvoz bančnih izpiskov";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button finishImportButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankDocData;
        private System.Windows.Forms.DataGridViewComboBoxColumn Member;
        private System.Windows.Forms.DataGridViewTextBoxColumn Years;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Warning;
        private System.Windows.Forms.Button cancelImportButton;


    }
}