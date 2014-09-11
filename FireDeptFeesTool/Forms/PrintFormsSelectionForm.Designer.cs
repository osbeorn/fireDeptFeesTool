namespace FireDeptFeesTool.Forms.UPNDocsList
{
    partial class PrintFormsSelectionForm
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
            this.printAllRadioButton = new System.Windows.Forms.RadioButton();
            this.printSelectionRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dueDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.endlessPaperRadioButton = new System.Windows.Forms.RadioButton();
            this.laserPaperRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // printAllRadioButton
            // 
            this.printAllRadioButton.AutoSize = true;
            this.printAllRadioButton.Location = new System.Drawing.Point(6, 19);
            this.printAllRadioButton.Name = "printAllRadioButton";
            this.printAllRadioButton.Size = new System.Drawing.Size(43, 17);
            this.printAllRadioButton.TabIndex = 0;
            this.printAllRadioButton.TabStop = true;
            this.printAllRadioButton.Text = "Vse";
            this.printAllRadioButton.UseVisualStyleBackColor = true;
            this.printAllRadioButton.CheckedChanged += new System.EventHandler(this.PrintAllRadioButton_CheckedChanged);
            // 
            // printSelectionRadioButton
            // 
            this.printSelectionRadioButton.AutoSize = true;
            this.printSelectionRadioButton.Location = new System.Drawing.Point(6, 42);
            this.printSelectionRadioButton.Name = "printSelectionRadioButton";
            this.printSelectionRadioButton.Size = new System.Drawing.Size(89, 17);
            this.printSelectionRadioButton.TabIndex = 1;
            this.printSelectionRadioButton.TabStop = true;
            this.printSelectionRadioButton.Text = "Samo izbrane";
            this.printSelectionRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.printAllRadioButton);
            this.groupBox1.Controls.Add(this.printSelectionRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Obseg tiskanja";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.dueDateDateTimePicker);
            this.groupBox2.Location = new System.Drawing.Point(3, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 46);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datum plačila";
            // 
            // dueDateDateTimePicker
            // 
            this.dueDateDateTimePicker.CustomFormat = "dd.MM.yyyy";
            this.dueDateDateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dueDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dueDateDateTimePicker.Location = new System.Drawing.Point(6, 19);
            this.dueDateDateTimePicker.Name = "dueDateDateTimePicker";
            this.dueDateDateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dueDateDateTimePicker.Size = new System.Drawing.Size(240, 20);
            this.dueDateDateTimePicker.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.acceptButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 233);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Location = new System.Drawing.Point(51, 201);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 4;
            this.acceptButton.Text = "Potrdi";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(132, 201);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Opusti";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox3, 2);
            this.groupBox3.Controls.Add(this.endlessPaperRadioButton);
            this.groupBox3.Controls.Add(this.laserPaperRadioButton);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 64);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tip papirja";
            // 
            // endlessPaperRadioButton
            // 
            this.endlessPaperRadioButton.AutoSize = true;
            this.endlessPaperRadioButton.Location = new System.Drawing.Point(6, 41);
            this.endlessPaperRadioButton.Name = "endlessPaperRadioButton";
            this.endlessPaperRadioButton.Size = new System.Drawing.Size(122, 17);
            this.endlessPaperRadioButton.TabIndex = 1;
            this.endlessPaperRadioButton.TabStop = true;
            this.endlessPaperRadioButton.Text = "Neskončni (3 nalogi)";
            this.endlessPaperRadioButton.UseVisualStyleBackColor = true;
            // 
            // laserPaperRadioButton
            // 
            this.laserPaperRadioButton.AutoSize = true;
            this.laserPaperRadioButton.Location = new System.Drawing.Point(6, 19);
            this.laserPaperRadioButton.Name = "laserPaperRadioButton";
            this.laserPaperRadioButton.Size = new System.Drawing.Size(114, 17);
            this.laserPaperRadioButton.TabIndex = 0;
            this.laserPaperRadioButton.TabStop = true;
            this.laserPaperRadioButton.Text = "Laserski (2 naloga)";
            this.laserPaperRadioButton.UseVisualStyleBackColor = true;
            this.laserPaperRadioButton.CheckedChanged += new System.EventHandler(this.LaserPaperRadioButton_CheckedChanged);
            // 
            // PrintFormsSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 233);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrintFormsSelectionForm";
            this.Text = "Izbor tiskanja";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton printAllRadioButton;
        private System.Windows.Forms.RadioButton printSelectionRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dueDateDateTimePicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton endlessPaperRadioButton;
        private System.Windows.Forms.RadioButton laserPaperRadioButton;
    }
}