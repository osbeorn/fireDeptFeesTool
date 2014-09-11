namespace FireDeptFeesTool.Forms
{
    partial class SelectYearRange
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
            this.yearsListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // yearsListBox
            // 
            this.yearsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yearsListBox.FormattingEnabled = true;
            this.yearsListBox.Location = new System.Drawing.Point(12, 12);
            this.yearsListBox.Name = "yearsListBox";
            this.yearsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.yearsListBox.Size = new System.Drawing.Size(224, 108);
            this.yearsListBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(128, 130);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Opusti";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Location = new System.Drawing.Point(47, 130);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "Potrdi";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // SelectYearRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 165);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.yearsListBox);
            this.Name = "SelectYearRange";
            this.Text = "Izbira let/obdobja";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox yearsListBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
    }
}