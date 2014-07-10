using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using FireDeptFeesTool.Enums;
using FireDeptFeesTool.Forms;
using FireDeptFeesTool.Forms.UPNDocsList;
using FireDeptFeesTool.Helpers;
using FireDeptFeesTool.Lib;
using FireDeptFeesTool.Model;

namespace FireDeptFeesTool.Controls
{
    public partial class BillsListControl : IListControl
    {
        #region format strings

        public const string BREME_IME = "{0} {1}, {2}";
        public const string BREME_SKLIC = "{0}-{1}";
        public const string DOBRO_MODEL = "SI00";
        public const string NAMEN = "PLAČILO ČLANARINE ZA LETO {0}";
        public const string KODA_NAMENA = "OTHR";

        #endregion format strings

        private int currentRow;
        public DateTime dueDate;
        public bool printAll;

        // default
        public PrintType printType = PrintType.Laser;
        private int rowCount;

        public int rowsPrinted;

        public BillsListControl(ShellForm container) : base(container)
        {
            InitializeComponent();

            DrawHelper.EnableControlDoubleBuffering("DataGridView", documentListDataGridView);
            //InitializeDataGridView();
        }

        public void InitializeDataGridView(int year)
        {
            var docs = new List<UPNDocument>();
            using (var db = new FeeStatusesDBContext())
            {
                var memberQuery = 
                    db.Member.
                    Where(m => m.MustPay && m.Active).
                    OrderBy(m => m.Surname).
                    ThenBy(m => m.Name);

                foreach (var member in memberQuery) // obvezniki za plačevanje članarine
                {
                    docs.Add(
                        new UPNDocument
                                {
                                    BremeIme = String.Format(BREME_IME, member.Surname, member.Name, member.Address), // član/plačnik
                                    DobroIBAN = ConfigHelper.GetConfigValue<string>(ConfigFields.IBAN_PREJEMNIKA), // IBAN prejemnika
                                    DobroModel = DOBRO_MODEL, // model sklica
                                    DobroSklic = String.Format(BREME_SKLIC, DateTime.Now.Year, member.VulkanID), // sklic == 'ID člana'-'tekoče leto'
                                    DobroIme = ConfigHelper.GetConfigValue<string>(ConfigFields.NAZIV_DRUSTVA), // prejemnik
                                    DobroBIC = ConfigHelper.GetConfigValue<string>(ConfigFields.BIC_BANKE), // bic banke
                                    Znesek = 
                                        (
                                            member.FeeLogs
                                                .Count(fl =>
                                                    (ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_OD) == 0 || fl.Year >= ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_OD)) &&
                                                    (ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_DO) == 0 || fl.Year <= ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_DO)) &&
                                                    fl.PaymentStatusID == PaymentStatus.NI_PLACAL
                                                ) + 1
                                        )
                                        *
                                        (
                                            member.Gender
                                            ? ConfigHelper.GetConfigValue<decimal>(ConfigFields.ZNESEK_CLANI)
                                            : ConfigHelper.GetConfigValue<decimal>(ConfigFields.ZNESEK_CLANICE)
                                        ),
                                    //DatumPlacila = DateTime.Now.ToString("dd.MM.yyyy"), // rok plačila
                                    Namen = String.Format(NAMEN, year), // namen
                                    KodaNamena = KODA_NAMENA // koda namena
                                }
                        );
                }
            }

            documentListDataGridView.DataSource = new SortableBindingList<UPNDocument>(docs);

            ClearSelection(documentListDataGridView);
            SelectRecords(true, year);
        }

        private void SelectRecords(bool onlyDebtors, int year)
        {
            using (var db = new FeeStatusesDBContext())
            {
                IQueryable<string> idList =
                    db.Member.
                        Where(m =>
                              m.MustPay &&
                              m.Active &&
                              m.FeeLogs.
                                  Where(fl =>
                                        fl.Year == year
                                  ).
                                  Any(fl =>
                                      fl.PaymentStatusID != PaymentStatus.PLACAL
                                  )
                        ).
                        Select(m => m.VulkanID);

                for (int i = 0; i < documentListDataGridView.Rows.Count; i++)
                {
                    var row = documentListDataGridView.Rows[i].DataBoundItem as UPNDocument;
                    if (row == null) continue;

                    if (idList.Contains(row.DobroSklic.Substring(5)))
                    {
                        row.Selected = true;
                    }
                }
            }

            documentListDataGridView.Refresh();
        }

        private void DocumentListDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var b = new SolidBrush(documentListDataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 25, e.RowBounds.Location.Y + 4);
            }
        }

        private void CancelGatheredDataButton_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (documentListDataGridView.Rows.Count < 1)
            {
                MessageBox.Show(WindowMessages.NO_DATA_AVAILABLE_FOR_PRINT, WindowMessages.WARNING_TITLE);
                return;
            }

            List<UPNDocument> selectedRows = documentListDataGridView.Rows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem).Cast<UPNDocument>().ToList();

            bool printAll =
                !selectedRows.Any(x => x.Selected) ||
                selectedRows.Count(x => x.Selected) == documentListDataGridView.Rows.Count;

            if (new PrintSelectionForm(this, printAll).ShowDialog() != DialogResult.OK)
                return;

            SetPrintSettings();

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                rowCount =
                    printAll
                        ? documentListDataGridView.Rows.Count
                        : selectedRows.Count(x => x.Selected);

                UPNPrintDocument.Print();
            }
        }

        private void SetPrintSettings()
        {
            var ps = new PaperSize();
            ps.RawKind = (int) PaperKind.A4;

            UPNPrintDocument.DefaultPageSettings.PaperSize = ps;
            UPNPrintDocument.DefaultPageSettings.Landscape = false; // default postavitev - pokoncno
            UPNPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0); // default odmiki - 0,0,0,0

            //pageSetupDialog1.Document = this.UPNPrintDocument;
            //pageSetupDialog1.ShowDialog();

            printDialog1.Document = UPNPrintDocument;
            printDialog1.AllowSomePages = true;
            printDialog1.AllowSelection = true;
            UPNPrintDocument.OriginAtMargins = false;
        }

        private void UPNPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            /* mere */
            // float pageWidth = 210f; // useless
            // float pageHeight = 297f; // useless

            float UPNFormHeight = 101.6f;
            float UPNTalonMargin = 60f;

            /* uporabniske nastavitve */
            float xOffset, yOffset;
            if (printType == PrintType.Laser)
            {
                //float xOffset = -4.1f; float yOffset = -3; // tiskalnik XEROX 3300MPF
                xOffset = ConfigHelper.GetConfigValue<float>(ConfigFields.LASER_XOFFSET);
                yOffset = ConfigHelper.GetConfigValue<float>(ConfigFields.LASER_YOFFSET);
            }
            else
            {
                //float xOffset = -4.9f; float yOffset = -4; // tiskalnik XEROX 3300MPF
                xOffset = ConfigHelper.GetConfigValue<float>(ConfigFields.ENDLESS_XOFFSET);
                yOffset = ConfigHelper.GetConfigValue<float>(ConfigFields.ENDLESS_YOFFSET);
            }

            /* fonti */
            var talonFont = new Font("Courier New", 7, FontStyle.Regular, GraphicsUnit.Point);
            var nalogFont = new Font("Courier New", 12, FontStyle.Regular, GraphicsUnit.Point);

            Debug.WriteLine("MarginBoundsLeft: " + e.MarginBounds.Left);
            Debug.WriteLine("MarginBoundsTop: " + e.MarginBounds.Top);

            var brush = new SolidBrush(Color.Black);
            var whiteBrush = new SolidBrush(Color.White);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            /*
            e.Graphics.DrawString("To je testni izpis za talon ...".ToUpperInvariant(), talonFont, brush, x, y);
            e.Graphics.DrawString("To je testni izpis za nalog ...".ToUpperInvariant(), nalogFont, brush, x, y + 20);
            */

            var farAlign = new StringFormat {Alignment = StringAlignment.Far};

            var farCenterAlign = new StringFormat
                                     {Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center};

            var nearAlign = new StringFormat {Alignment = StringAlignment.Near};

            var nearCenterAlign = new StringFormat
                                      {Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center};

            UPNDocument docRow;
            for (int i = 0; i < (printType == PrintType.Laser ? 2 : 3);)
                // laser paper contains 2 documents, endless contains 3
            {
                if (rowsPrinted == rowCount /* || currentRow >= rowCount*/)
                    break;

                docRow = documentListDataGridView.Rows[currentRow].DataBoundItem as UPNDocument;
                if (!printAll && !(docRow.Selected))
                {
                    currentRow++;
                    continue;
                }

                docRow = documentListDataGridView.Rows[currentRow++].DataBoundItem as UPNDocument;
                docRow.DatumPlacila = dueDate.ToString("dd.MM.yyyy");

                float yMargin;
                if (printType == PrintType.Laser)
                {
                    yMargin =
                        i%2 == 0
                            ? 23.45f
                            : 23.45f*3 + UPNFormHeight;
                }
                else
                {
                    yMargin = i*UPNFormHeight;
                }

                #region obmocja-talon

                /* ime placnika*/
                var imePlacnikaT = new UPNRectangle(4.00f, 93.25f, 57.00f, 84.25f, UPNFormHeight, yMargin, xOffset, yOffset);
                /* namen / rok placila */
                var namenRokPlacilaT = new UPNRectangle(4.00f, 80.75f, 57.00f, 71.75f, UPNFormHeight, yMargin, xOffset, yOffset);
                /* znesek */
                var znesekT = new UPNRectangle(17.00f, 68.25f, 57.00f, 63.25f, UPNFormHeight, yMargin, xOffset, yOffset);
                /* IBANPrejemnika in BIC banke prejemnika */
                var IBANPrejemnikaT = new UPNRectangle(4.00f, 59.75f, 57.00f, 46.25f, UPNFormHeight, yMargin, xOffset, yOffset);
                /* referenca prejemnika */
                var referencaPrejemnikaT = new UPNRectangle(4.00f, 42.75f, 57.00f, 37.75f, UPNFormHeight, yMargin, xOffset, yOffset);
                /* ime prejemnika */
                var imePrejemnikaT = new UPNRectangle(4.00f, 34.25f, 57.00f, 25.25f, UPNFormHeight, yMargin, xOffset, yOffset);

                #endregion obmocja-talon

                #region obmocja-nalog

                /* IBAN placnika */
                var IBANPlacnikaN = new UPNRectangle(3.75f, 97.75f, 75.00f, 92.75f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* referenca placnika - SIXX */
                var referencaPlacnika1N = new UPNRectangle(3.75f, 89.25f, 18.75f, 84.25f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* referenca placnika - preostalo */
                var referencaPlacnika2N = new UPNRectangle(20.75f, 89.25f, 103.25f, 84.25f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* ime placnika */
                var imePlacnikaN = new UPNRectangle(3.75f, 80.75f, 103.25f, 71.75f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* koda namena */
                var kodaNamenaN = new UPNRectangle(3.75f, 68.25f, 18.75f, 63.25f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* namen / rok placila */
                var namenRokPlacilaN = new UPNRectangle(22.50f, 68.25f, 135.00f, 63.25f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* znesek */
                var znesekN = new UPNRectangle(15.00f, 59.75f, 56.22f, 54.75f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* datum placila */
                var datumPlacilaN = new UPNRectangle(60.00f, 59.75f, 90.02f, 54.75f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* bic banke prejemnika */
                var BICBankeN = new UPNRectangle(93.75f, 59.75f, 135.00f, 54.75f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* IBAN prejemnika */
                var IBANPrejemnikaN = new UPNRectangle(3.75f, 51.25f, 131.25f, 46.25f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* referenca - SIXX */
                var referencaPrejemnika1N = new UPNRectangle(3.75f, 42.75f, 18.75f, 37.75f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* referenca - preostalo */
                var referencaPrejemnika2N = new UPNRectangle(20.75f, 42.75f, 103.25f, 37.75f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);
                /* ime prejmenika */
                var imePrejemnikaN = new UPNRectangle(3.75f, 34.25f, 135.00f, 25.25f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);

                #endregion obmocja-nalog

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), imePlacnikaT.X, imePlacnikaT.Y, imePlacnikaT.Width, imePlacnikaT.Height);
                e.Graphics.DrawString(docRow.BremeIme, talonFont, brush, new RectangleF(imePlacnikaT.X, imePlacnikaT.Y + 0.4f, imePlacnikaT.Width, imePlacnikaT.Height), nearAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), namenRokPlacilaT.X, namenRokPlacilaT.Y, namenRokPlacilaT.Width, namenRokPlacilaT.Height);
                e.Graphics.DrawString(docRow.Namen, talonFont, brush, new RectangleF(namenRokPlacilaT.X, namenRokPlacilaT.Y + 0.4f, namenRokPlacilaT.Width, namenRokPlacilaT.Height), nearAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), znesekT.X, znesekT.Y, znesekT.Width, znesekT.Height);
                e.Graphics.DrawString(String.Join("", "***", docRow.Znesek.ToString("F")), talonFont, brush, new RectangleF(znesekT.X, znesekT.Y + 0.4f, znesekT.Width, znesekT.Height), nearAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), IBANPrejemnikaT.X, IBANPrejemnikaT.Y, IBANPrejemnikaT.Width, IBANPrejemnikaT.Height);
                e.Graphics.DrawString(
                    String.Join(", ",
                                String.Format("{0} {1} {2} {3} {4}", docRow.DobroIBAN.Substring(0, 4),
                                              docRow.DobroIBAN.Substring(4, 4), docRow.DobroIBAN.Substring(8, 4),
                                              docRow.DobroIBAN.Substring(12, 4), docRow.DobroIBAN.Substring(16)),
                                docRow.DobroBIC), talonFont, brush,
                    new RectangleF(IBANPrejemnikaT.X, IBANPrejemnikaT.Y, IBANPrejemnikaT.Width, IBANPrejemnikaT.Height),
                    nearAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), referencaPrejemnikaT.X, referencaPrejemnikaT.Y, referencaPrejemnikaT.Width, referencaPrejemnikaT.Height);
                e.Graphics.DrawString(String.Join(" ", docRow.DobroModel, docRow.DobroSklic), talonFont, brush, new RectangleF(referencaPrejemnikaT.X, referencaPrejemnikaT.Y, referencaPrejemnikaT.Width, referencaPrejemnikaT.Height), nearAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), imePrejemnikaT.X, imePrejemnikaT.Y, imePrejemnikaT.Width, imePrejemnikaT.Height);
                e.Graphics.DrawString(docRow.DobroIme, talonFont, brush, new RectangleF(imePrejemnikaT.X, imePrejemnikaT.Y, imePrejemnikaT.Width, imePrejemnikaT.Height), nearAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), IBANPlacnikaN.X, IBANPlacnikaN.Y, IBANPlacnikaN.Width, IBANPlacnikaN.Height);
                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), referencaPlacnika1N.X, referencaPlacnika1N.Y, referencaPlacnika1N.Width, referencaPlacnika1N.Height);
                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), referencaPlacnika2N.X, referencaPlacnika2N.Y, referencaPlacnika2N.Width, referencaPlacnika2N.Height);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), imePlacnikaN.X, imePlacnikaN.Y, imePlacnikaN.Width, imePlacnikaN.Height);
                e.Graphics.DrawString(docRow.BremeIme, nalogFont, brush, new RectangleF(imePlacnikaN.X, imePlacnikaN.Y, imePlacnikaN.Width, imePlacnikaN.Height), nearCenterAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), kodaNamenaN.X, kodaNamenaN.Y, kodaNamenaN.Width, kodaNamenaN.Height);
                e.Graphics.DrawString(docRow.KodaNamena, nalogFont, brush, new RectangleF(kodaNamenaN.X, kodaNamenaN.Y, kodaNamenaN.Width, kodaNamenaN.Height), nearCenterAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), namenRokPlacilaN.X, namenRokPlacilaN.Y, namenRokPlacilaN.Width, namenRokPlacilaN.Height);
                e.Graphics.DrawString(docRow.Namen, nalogFont, brush, new RectangleF(namenRokPlacilaN.X, namenRokPlacilaN.Y, namenRokPlacilaN.Width, namenRokPlacilaN.Height), nearCenterAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), znesekN.X, znesekN.Y, znesekN.Width, znesekN.Height);
                e.Graphics.DrawString(String.Join("", "***", docRow.Znesek.ToString("F")), nalogFont, brush, new RectangleF(znesekN.X, znesekN.Y, znesekN.Width, znesekN.Height), farCenterAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), datumPlacilaN.X, datumPlacilaN.Y, datumPlacilaN.Width, datumPlacilaN.Height);
                e.Graphics.DrawString(docRow.DatumPlacila, nalogFont, brush, new RectangleF(datumPlacilaN.X, datumPlacilaN.Y, datumPlacilaN.Width, datumPlacilaN.Height), nearCenterAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), BICBankeN.X, BICBankeN.Y, BICBankeN.Width, BICBankeN.Height);
                e.Graphics.DrawString(docRow.DobroBIC, nalogFont, brush, new RectangleF(BICBankeN.X, BICBankeN.Y, BICBankeN.Width, BICBankeN.Height), nearCenterAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), IBANPrejemnikaN.X, IBANPrejemnikaN.Y, IBANPrejemnikaN.Width, IBANPrejemnikaN.Height);
                e.Graphics.DrawString(
                    String.Join(", ",
                                String.Format("{0} {1} {2} {3} {4}", docRow.DobroIBAN.Substring(0, 4),
                                              docRow.DobroIBAN.Substring(4, 4), docRow.DobroIBAN.Substring(8, 4),
                                              docRow.DobroIBAN.Substring(12, 4), docRow.DobroIBAN.Substring(16))),
                    nalogFont, brush,
                    new RectangleF(IBANPrejemnikaN.X, IBANPrejemnikaN.Y, IBANPrejemnikaN.Width, IBANPrejemnikaN.Height),
                    nearCenterAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), referencaPrejemnika1N.X, referencaPrejemnika1N.Y, referencaPrejemnika1N.Width, referencaPrejemnika1N.Height);
                e.Graphics.DrawString(docRow.DobroModel, nalogFont, brush, new RectangleF(referencaPrejemnika1N.X, referencaPrejemnika1N.Y, referencaPrejemnika1N.Width, referencaPrejemnika1N.Height), nearCenterAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), referencaPrejemnika2N.X, referencaPrejemnika2N.Y, referencaPrejemnika2N.Width, referencaPrejemnika2N.Height);
                e.Graphics.DrawString(docRow.DobroSklic, nalogFont, brush, new RectangleF(referencaPrejemnika2N.X, referencaPrejemnika2N.Y, referencaPrejemnika2N.Width, referencaPrejemnika2N.Height), nearCenterAlign);

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), imePrejemnikaN.X, imePrejemnikaN.Y, imePrejemnikaN.Width, imePrejemnikaN.Height);
                e.Graphics.DrawString(docRow.DobroIme, nalogFont, brush, new RectangleF(imePrejemnikaN.X, imePrejemnikaN.Y, imePrejemnikaN.Width, imePrejemnikaN.Height), nearCenterAlign);

                rowsPrinted++;
                i++;
            }

            if (rowsPrinted == rowCount)
            {
                e.HasMorePages = false;
                currentRow = 0;
            }
            else
            {
                e.HasMorePages = true;
            }
        }

        public override void BindData(bool overrideDefaultFlow)
        {
            if (!overrideDefaultFlow && !RefreshOnNextLoad) return;

            // Do nothing
            // InitializeDataGridView();

            RefreshOnNextLoad = false;
        }

        public override void SaveChanges(bool notifyUser)
        {
        }

        public override void OnClosing()
        {
        }

        private void BillsListControl_VisibleChanged(object sender, EventArgs e)
        {
            // Do nothing
            // ClearSelection(documentListDataGridView);
            // SelectRecords(true);
        }

        private void PrepareBillsDataButton_Click(object sender, EventArgs e)
        {
            //InitializeDataGridView();
            prepareBillsContextMenuStrip.Show(prepareBillsDataButton, new Point(0, prepareBillsDataButton.Height));
        }

        private void PrepareDataForCurrentYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeDataGridView(DateTime.Now.Year);
        }

        private void PrepareDataForSelectedYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectYear = new SelectYearForm();

            if (selectYear.ShowDialog() == DialogResult.OK)
            {
                InitializeDataGridView(selectYear.Year);
            }
        }

        #region OBSOLETE_SAVE_TO_IZPISUPN_DB

        /*
        private void saveGatheredDataButton_Click(object sender, EventArgs e)
        {
            pgdDataSet = new PGD_ZAGRADEC_CLANARINEDataSet();
            PGD_ZAGRADEC_CLANARINEDataSet.PaketRow pgdDataRow;

            try
            {
                foreach (DataGridViewRow row in this.documentListDataGridView.Rows)
                {
                    pgdDataRow = pgdDataSet.Paket.NewPaketRow();

                    UPNDocument docRow = row.DataBoundItem as UPNDocument;
                    if (docRow.Selected)
                    {
                        pgdDataRow.TipDokumenta = docRow.TipDokumenta;
                        pgdDataRow.BremeIBAN = docRow.BremeIBAN;
                        pgdDataRow.BremeModel = docRow.BremeModel;
                        pgdDataRow.BremeSklic = docRow.BremeSklic;
                        pgdDataRow.BremeIme = docRow.BremeIme;
                        pgdDataRow.DobroIBAN = docRow.DobroIBAN;
                        pgdDataRow.DobroModel = docRow.DobroModel;
                        pgdDataRow.DobroSklic = docRow.DobroSklic;
                        pgdDataRow.DobroIme = docRow.DobroIme;
                        pgdDataRow.DobroBIC = docRow.DobroBIC;
                        pgdDataRow.Znesek = docRow.Znesek;
                        pgdDataRow.DatumPlacila = docRow.DatumPlacila;
                        pgdDataRow.Namen = docRow.Namen;
                        pgdDataRow.KodaNamena = docRow.KodaNamena;
                        pgdDataRow.Nujno = docRow.Nujno;
                        pgdDataRow.Izjava = docRow.Izjava;
                        pgdDataRow.ObvezenVnosVsehPolj = docRow.ObvezenVnosVsehPolj;
                        pgdDataRow.PreveriKontrolneStevilke = docRow.PreveriKontrolneStevilke;
                        pgdDataRow.SamodejnoPripraviOCR = docRow.SamodejnoPripraviOCR;

                        pgdDataSet.Paket.AddPaketRow(pgdDataRow);
                    }
                }

                paketTableAdapter1.Update(pgdDataSet.Paket);

                MessageBox.Show(this, "Uvoz podatkov uspešno končan!", "Uvoz uspešen", MessageBoxButtons.OK, MessageBoxIcon.None);

                this.Hide();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Kritična napaka pri zapisovanju podatkov:\n" + ex.ToString(), "Kritična napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        #endregion OBSOLETE_SAVE_TO_IZPISUPN_DB
    }
}