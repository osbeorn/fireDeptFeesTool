namespace FireDeptFeesTool.Forms
{
    partial class ShellForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.membersTabPage = new System.Windows.Forms.TabPage();
            this.paymentsTabPage = new System.Windows.Forms.TabPage();
            this.billsTabPage = new System.Windows.Forms.TabPage();
            this.remindersTabPage = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datotekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orodjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomočToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsTabPage = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.membersTabPage);
            this.tabControl.Controls.Add(this.paymentsTabPage);
            this.tabControl.Controls.Add(this.billsTabPage);
            this.tabControl.Controls.Add(this.remindersTabPage);
            this.tabControl.Controls.Add(this.statisticsTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(992, 696);
            this.tabControl.TabIndex = 1;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
            this.tabControl.Deselected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1_Deselected);
            // 
            // membersTabPage
            // 
            this.membersTabPage.Location = new System.Drawing.Point(4, 22);
            this.membersTabPage.Name = "membersTabPage";
            this.membersTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.membersTabPage.Size = new System.Drawing.Size(984, 670);
            this.membersTabPage.TabIndex = 0;
            this.membersTabPage.Tag = "0";
            this.membersTabPage.Text = "Seznam članov";
            this.membersTabPage.UseVisualStyleBackColor = true;
            // 
            // paymentsTabPage
            // 
            this.paymentsTabPage.Location = new System.Drawing.Point(4, 22);
            this.paymentsTabPage.Name = "paymentsTabPage";
            this.paymentsTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.paymentsTabPage.Size = new System.Drawing.Size(984, 670);
            this.paymentsTabPage.TabIndex = 1;
            this.paymentsTabPage.Tag = "1";
            this.paymentsTabPage.Text = "Seznam članarin";
            this.paymentsTabPage.UseVisualStyleBackColor = true;
            // 
            // billsTabPage
            // 
            this.billsTabPage.Location = new System.Drawing.Point(4, 22);
            this.billsTabPage.Name = "billsTabPage";
            this.billsTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.billsTabPage.Size = new System.Drawing.Size(984, 670);
            this.billsTabPage.TabIndex = 2;
            this.billsTabPage.Tag = "2";
            this.billsTabPage.Text = "Položnice";
            this.billsTabPage.UseVisualStyleBackColor = true;
            // 
            // remindersTabPage
            // 
            this.remindersTabPage.Location = new System.Drawing.Point(4, 22);
            this.remindersTabPage.Name = "remindersTabPage";
            this.remindersTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.remindersTabPage.Size = new System.Drawing.Size(984, 670);
            this.remindersTabPage.TabIndex = 3;
            this.remindersTabPage.Tag = "3";
            this.remindersTabPage.Text = "Opomini";
            this.remindersTabPage.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datotekaToolStripMenuItem,
            this.orodjaToolStripMenuItem,
            this.pomočToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // datotekaToolStripMenuItem
            // 
            this.datotekaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.datotekaToolStripMenuItem.Name = "datotekaToolStripMenuItem";
            this.datotekaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.datotekaToolStripMenuItem.Text = "Datoteka";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem.Text = "Izhod";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // orodjaToolStripMenuItem
            // 
            this.orodjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSettingsToolStripMenuItem});
            this.orodjaToolStripMenuItem.Name = "orodjaToolStripMenuItem";
            this.orodjaToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.orodjaToolStripMenuItem.Text = "Orodja";
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.openSettingsToolStripMenuItem.Text = "Nastavitve...";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.OpenSettingsToolStripMenuItem_Click);
            // 
            // pomočToolStripMenuItem
            // 
            this.pomočToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.pomočToolStripMenuItem.Name = "pomočToolStripMenuItem";
            this.pomočToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomočToolStripMenuItem.Text = "Pomoč";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aboutToolStripMenuItem.Text = "O programu";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // statisticsTabPage
            // 
            this.statisticsTabPage.Location = new System.Drawing.Point(4, 22);
            this.statisticsTabPage.Name = "statisticsTabPage";
            this.statisticsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.statisticsTabPage.Size = new System.Drawing.Size(984, 670);
            this.statisticsTabPage.TabIndex = 4;
            this.statisticsTabPage.Text = "Statistika";
            this.statisticsTabPage.UseVisualStyleBackColor = true;
            // 
            // ShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 720);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1000, 750);
            this.Name = "ShellForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Članarine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShellForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage membersTabPage;
        private System.Windows.Forms.TabPage paymentsTabPage;
        private System.Windows.Forms.TabPage billsTabPage;
        private System.Windows.Forms.TabPage remindersTabPage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datotekaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orodjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomočToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage statisticsTabPage;
    }
}