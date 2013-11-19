namespace FireDeptFeesTool.Forms
{
    partial class ManageSettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.nazivDrustvaTextBox = new System.Windows.Forms.TextBox();
            this.IBANPrejemnikaTextBox = new System.Windows.Forms.TextBox();
            this.BICBankeTextBox = new System.Windows.Forms.TextBox();
            this.znesekTextBox = new System.Windows.Forms.TextBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.formToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.laserXOffsetTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.laserYOffsetTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.endlessXOffsetTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.endlessYOffsetTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.debtsTemplateTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.selectTemplateOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // nazivDrustvaTextBox
            // 
            this.nazivDrustvaTextBox.Location = new System.Drawing.Point(84, 19);
            this.nazivDrustvaTextBox.Name = "nazivDrustvaTextBox";
            this.nazivDrustvaTextBox.Size = new System.Drawing.Size(432, 20);
            this.nazivDrustvaTextBox.TabIndex = 0;
            // 
            // IBANPrejemnikaTextBox
            // 
            this.IBANPrejemnikaTextBox.Location = new System.Drawing.Point(84, 45);
            this.IBANPrejemnikaTextBox.Name = "IBANPrejemnikaTextBox";
            this.IBANPrejemnikaTextBox.Size = new System.Drawing.Size(432, 20);
            this.IBANPrejemnikaTextBox.TabIndex = 1;
            // 
            // BICBankeTextBox
            // 
            this.BICBankeTextBox.Location = new System.Drawing.Point(84, 71);
            this.BICBankeTextBox.Name = "BICBankeTextBox";
            this.BICBankeTextBox.Size = new System.Drawing.Size(432, 20);
            this.BICBankeTextBox.TabIndex = 2;
            // 
            // znesekTextBox
            // 
            this.znesekTextBox.Location = new System.Drawing.Point(84, 97);
            this.znesekTextBox.Name = "znesekTextBox";
            this.znesekTextBox.Size = new System.Drawing.Size(432, 20);
            this.znesekTextBox.TabIndex = 3;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(196, 383);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.saveSettingsButton.TabIndex = 4;
            this.saveSettingsButton.Text = "Potrdi";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Naziv društva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "IBAN društva";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "BIC banke";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Znesek (€)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Opusti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CancelSettingsButton_Click);
            // 
            // laserXOffsetTextBox
            // 
            this.laserXOffsetTextBox.Location = new System.Drawing.Point(84, 19);
            this.laserXOffsetTextBox.Name = "laserXOffsetTextBox";
            this.laserXOffsetTextBox.Size = new System.Drawing.Size(432, 20);
            this.laserXOffsetTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Odmik X (mm)";
            // 
            // laserYOffsetTextBox
            // 
            this.laserYOffsetTextBox.Location = new System.Drawing.Point(84, 45);
            this.laserYOffsetTextBox.MinimumSize = new System.Drawing.Size(432, 20);
            this.laserYOffsetTextBox.Name = "laserYOffsetTextBox";
            this.laserYOffsetTextBox.Size = new System.Drawing.Size(432, 20);
            this.laserYOffsetTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Odmik Y (mm)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nazivDrustvaTextBox);
            this.groupBox1.Controls.Add(this.IBANPrejemnikaTextBox);
            this.groupBox1.Controls.Add(this.BICBankeTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.znesekTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 132);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podatki za tiskanje";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.laserXOffsetTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.laserYOffsetTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 79);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Odmik (laserski papir)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.endlessXOffsetTextBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.endlessYOffsetTextBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 235);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(522, 80);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Odmik (neskončni papir)";
            // 
            // endlessXOffsetTextBox
            // 
            this.endlessXOffsetTextBox.Location = new System.Drawing.Point(84, 19);
            this.endlessXOffsetTextBox.Name = "endlessXOffsetTextBox";
            this.endlessXOffsetTextBox.Size = new System.Drawing.Size(432, 20);
            this.endlessXOffsetTextBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Odmik X (mm)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Odmik Y (mm)";
            // 
            // endlessYOffsetTextBox
            // 
            this.endlessYOffsetTextBox.Location = new System.Drawing.Point(84, 45);
            this.endlessYOffsetTextBox.Name = "endlessYOffsetTextBox";
            this.endlessYOffsetTextBox.Size = new System.Drawing.Size(432, 20);
            this.endlessYOffsetTextBox.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.debtsTemplateTextBox);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(12, 321);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(522, 54);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Opomini";
            // 
            // debtsTemplateTextBox
            // 
            this.debtsTemplateTextBox.Location = new System.Drawing.Point(84, 21);
            this.debtsTemplateTextBox.Name = "debtsTemplateTextBox";
            this.debtsTemplateTextBox.ReadOnly = true;
            this.debtsTemplateTextBox.Size = new System.Drawing.Size(402, 20);
            this.debtsTemplateTextBox.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(492, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 20);
            this.button2.TabIndex = 3;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Predloga";
            // 
            // selectTemplateOpenFileDialog
            // 
            this.selectTemplateOpenFileDialog.Filter = "Text Files|*.txt";
            // 
            // ManageSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 418);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveSettingsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(552, 378);
            this.Name = "ManageSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Urejanje nastavitev";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox nazivDrustvaTextBox;
        private System.Windows.Forms.TextBox IBANPrejemnikaTextBox;
        private System.Windows.Forms.TextBox BICBankeTextBox;
        private System.Windows.Forms.TextBox znesekTextBox;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip formToolTip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox laserXOffsetTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox laserYOffsetTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox endlessXOffsetTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox endlessYOffsetTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox debtsTemplateTextBox;
        private System.Windows.Forms.OpenFileDialog selectTemplateOpenFileDialog;
    }
}