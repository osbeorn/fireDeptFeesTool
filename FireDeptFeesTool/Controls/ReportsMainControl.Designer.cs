namespace FireDeptFeesTool.Controls
{
    partial class ReportsMainControl
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
            this.reportsSubControlsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.showStatisticButton = new System.Windows.Forms.Button();
            this.reportsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // reportsSubControlsPanel
            // 
            this.reportsSubControlsPanel.ColumnCount = 2;
            this.reportsSubControlsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.reportsSubControlsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.reportsSubControlsPanel.Location = new System.Drawing.Point(257, 3);
            this.reportsSubControlsPanel.Name = "reportsSubControlsPanel";
            this.reportsSubControlsPanel.RowCount = 1;
            this.reportsSubControlsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.reportsSubControlsPanel.Size = new System.Drawing.Size(281, 358);
            this.reportsSubControlsPanel.TabIndex = 3;
            // 
            // showStatisticButton
            // 
            this.showStatisticButton.Location = new System.Drawing.Point(176, 182);
            this.showStatisticButton.Name = "showStatisticButton";
            this.showStatisticButton.Size = new System.Drawing.Size(75, 23);
            this.showStatisticButton.TabIndex = 2;
            this.showStatisticButton.Text = "Prikaži";
            this.showStatisticButton.UseVisualStyleBackColor = true;
            this.showStatisticButton.Click += new System.EventHandler(this.showReportButton_Click);
            // 
            // reportsListBox
            // 
            this.reportsListBox.FormattingEnabled = true;
            this.reportsListBox.Location = new System.Drawing.Point(3, 3);
            this.reportsListBox.Name = "reportsListBox";
            this.reportsListBox.Size = new System.Drawing.Size(248, 173);
            this.reportsListBox.TabIndex = 0;
            this.reportsListBox.SelectedIndexChanged += new System.EventHandler(this.reportsListBox_SelectedIndexChanged);
            // 
            // ReportsMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportsSubControlsPanel);
            this.Controls.Add(this.showStatisticButton);
            this.Controls.Add(this.reportsListBox);
            this.Name = "ReportsMainControl";
            this.Size = new System.Drawing.Size(538, 361);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox reportsListBox;
        private System.Windows.Forms.Button showStatisticButton;
        private System.Windows.Forms.TableLayoutPanel reportsSubControlsPanel;
    }
}
