namespace FireDeptFeesTool.Controls
{
    partial class BillsListControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.UPNPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.documentListDataGridView = new System.Windows.Forms.DataGridView();
            this.prepareBillsDataButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.prepareBillsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.prepareDataForCurrentYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prepareDataForSelectedYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BremeIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobroIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Znesek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobroIBAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobroBIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobroModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobroSklic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumPlacila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodaNamena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentListDataGridView)).BeginInit();
            this.prepareBillsContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.UPNPrintDocument;
            // 
            // UPNPrintDocument
            // 
            this.UPNPrintDocument.DocumentName = "UPNDocument";
            this.UPNPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.UPNPrintDocument_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.documentListDataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.prepareBillsDataButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.printButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 403);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // documentListDataGridView
            // 
            this.documentListDataGridView.AllowUserToAddRows = false;
            this.documentListDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.documentListDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.documentListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.documentListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.BremeIme,
            this.DobroIme,
            this.Znesek,
            this.DobroIBAN,
            this.DobroBIC,
            this.DobroModel,
            this.DobroSklic,
            this.DatumPlacila,
            this.KodaNamena});
            this.tableLayoutPanel1.SetColumnSpan(this.documentListDataGridView, 3);
            this.documentListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentListDataGridView.Location = new System.Drawing.Point(3, 3);
            this.documentListDataGridView.Name = "documentListDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.documentListDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.documentListDataGridView.RowHeadersWidth = 50;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Azure;
            this.documentListDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.documentListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.documentListDataGridView.Size = new System.Drawing.Size(594, 362);
            this.documentListDataGridView.TabIndex = 0;
            this.documentListDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DocumentListDataGridView_RowPostPaint);
            // 
            // prepareBillsDataButton
            // 
            this.prepareBillsDataButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.prepareBillsDataButton.Location = new System.Drawing.Point(523, 374);
            this.prepareBillsDataButton.Name = "prepareBillsDataButton";
            this.prepareBillsDataButton.Size = new System.Drawing.Size(74, 23);
            this.prepareBillsDataButton.TabIndex = 2;
            this.prepareBillsDataButton.Text = "Pripravi";
            this.prepareBillsDataButton.UseVisualStyleBackColor = true;
            this.prepareBillsDataButton.Click += new System.EventHandler(this.PrepareBillsDataButton_Click);
            // 
            // printButton
            // 
            this.printButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.printButton.Location = new System.Drawing.Point(3, 374);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(74, 23);
            this.printButton.TabIndex = 3;
            this.printButton.Text = "Tiskaj...";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // prepareBillsContextMenuStrip
            // 
            this.prepareBillsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prepareDataForCurrentYearToolStripMenuItem,
            this.prepareDataForSelectedYearToolStripMenuItem});
            this.prepareBillsContextMenuStrip.Name = "prepareBillsContextMenuStrip";
            this.prepareBillsContextMenuStrip.Size = new System.Drawing.Size(171, 48);
            // 
            // prepareDataForCurrentYearToolStripMenuItem
            // 
            this.prepareDataForCurrentYearToolStripMenuItem.Name = "prepareDataForCurrentYearToolStripMenuItem";
            this.prepareDataForCurrentYearToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.prepareDataForCurrentYearToolStripMenuItem.Text = "Za tekoče leto";
            this.prepareDataForCurrentYearToolStripMenuItem.Click += new System.EventHandler(this.PrepareDataForCurrentYearToolStripMenuItem_Click);
            // 
            // prepareDataForSelectedYearToolStripMenuItem
            // 
            this.prepareDataForSelectedYearToolStripMenuItem.Name = "prepareDataForSelectedYearToolStripMenuItem";
            this.prepareDataForSelectedYearToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.prepareDataForSelectedYearToolStripMenuItem.Text = "Za poljubno leto...";
            this.prepareDataForSelectedYearToolStripMenuItem.Click += new System.EventHandler(this.PrepareDataForSelectedYearToolStripMenuItem_Click);
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "";
            this.Selected.Name = "Selected";
            this.Selected.Width = 5;
            // 
            // BremeIme
            // 
            this.BremeIme.DataPropertyName = "BremeIme";
            this.BremeIme.HeaderText = "Breme ime";
            this.BremeIme.Name = "BremeIme";
            this.BremeIme.Width = 81;
            // 
            // DobroIme
            // 
            this.DobroIme.DataPropertyName = "DobroIme";
            this.DobroIme.HeaderText = "Dobro ime";
            this.DobroIme.Name = "DobroIme";
            this.DobroIme.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DobroIme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DobroIme.Width = 61;
            // 
            // Znesek
            // 
            this.Znesek.DataPropertyName = "Znesek";
            this.Znesek.HeaderText = "Znesek (€)";
            this.Znesek.Name = "Znesek";
            this.Znesek.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Znesek.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Znesek.Width = 64;
            // 
            // DobroIBAN
            // 
            this.DobroIBAN.DataPropertyName = "DobroIBAN";
            this.DobroIBAN.HeaderText = "Dobro IBAN";
            this.DobroIBAN.Name = "DobroIBAN";
            this.DobroIBAN.Width = 89;
            // 
            // DobroBIC
            // 
            this.DobroBIC.DataPropertyName = "DobroBIC";
            this.DobroBIC.HeaderText = "Dobro BIC";
            this.DobroBIC.Name = "DobroBIC";
            this.DobroBIC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DobroBIC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DobroBIC.Width = 62;
            // 
            // DobroModel
            // 
            this.DobroModel.DataPropertyName = "DobroModel";
            this.DobroModel.HeaderText = "Dobro model";
            this.DobroModel.Name = "DobroModel";
            this.DobroModel.Width = 92;
            // 
            // DobroSklic
            // 
            this.DobroSklic.DataPropertyName = "DobroSklic";
            this.DobroSklic.HeaderText = "Dobro sklic";
            this.DobroSklic.Name = "DobroSklic";
            this.DobroSklic.Width = 85;
            // 
            // DatumPlacila
            // 
            this.DatumPlacila.DataPropertyName = "DatumPlacila";
            this.DatumPlacila.HeaderText = "Datum plačila";
            this.DatumPlacila.Name = "DatumPlacila";
            this.DatumPlacila.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DatumPlacila.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DatumPlacila.Visible = false;
            this.DatumPlacila.Width = 77;
            // 
            // KodaNamena
            // 
            this.KodaNamena.DataPropertyName = "KodaNamena";
            this.KodaNamena.HeaderText = "Koda namena";
            this.KodaNamena.Name = "KodaNamena";
            this.KodaNamena.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.KodaNamena.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KodaNamena.Width = 79;
            // 
            // BillsListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "BillsListControl";
            this.Size = new System.Drawing.Size(600, 403);
            this.VisibleChanged += new System.EventHandler(this.BillsListControl_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentListDataGridView)).EndInit();
            this.prepareBillsContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView documentListDataGridView;
        private System.Windows.Forms.Button prepareBillsDataButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument UPNPrintDocument;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ContextMenuStrip prepareBillsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem prepareDataForCurrentYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prepareDataForSelectedYearToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn BremeIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn DobroIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Znesek;
        private System.Windows.Forms.DataGridViewTextBoxColumn DobroIBAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DobroBIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DobroModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DobroSklic;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumPlacila;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodaNamena;
    }
}
