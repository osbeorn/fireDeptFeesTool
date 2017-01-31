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
using FireDeptFeesTool.ViewModels;
using Microsoft.Reporting.WinForms;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace FireDeptFeesTool.Controls
{
    public partial class BillsListControl : IListControl
    {
        #region format strings

        public const string BREME_IME = "{0} {1}, {2}";
        public const string BREME_SKLIC = "{0}-{1}";
        public const string BREME_SKLIC_12 = "{0}0{1}0";
        public const string DOBRO_MODEL = "SI00";
        public const string DOBRO_MODEL_12 = "SI12";
        public const string NAMEN = "PLAČILO ČLANARINE ZA LETO {0}";
        public const string KODA_NAMENA = "OTHR";
        public const string VRSTICA_OCR = "{0} {1} {2} {3} {4}";

        #endregion format strings

        #region constants

        public const string REPORT_PATH = "FireDeptFeesTool.Reports.MemberStickers2x7.rdlc";

        #endregion

        private int currentRow;
        public DateTime dueDate;
        public bool printAll;
        public int stickersToSkip;
        public string stickerFormat;

        // default
        public PaperType paperType = PaperType.Laser;
        private int rowCount;

        public int rowsPrinted;

        public BillsListControl(ShellForm container) : base(container)
        {
            InitializeComponent();

            DrawHelper.EnableControlDoubleBuffering("DataGridView", documentListDataGridView);
            //InitializeDataGridView();
        }

        public void InitializeDataGridView(int year, bool includeDebts)
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
                    var dobroSklic = String.Format(BREME_SKLIC_12, DateTime.Now.Year, member.VulkanID);
                    dobroSklic = GenerateControlNumber(dobroSklic);

                    docs.Add(
                        new UPNDocument
                            {
                                BremeIme = String.Format(BREME_IME, member.Surname, member.Name, member.Address), // član/plačnik
                                DobroIBAN = ConfigHelper.GetConfigValue<string>(ConfigFields.IBAN_PREJEMNIKA), // IBAN prejemnika
                                DobroModel = DOBRO_MODEL_12, // model sklica
                                DobroSklic = dobroSklic, // sklic == 'tekoče leto'0'ID člana'0'kontrolna številka'
                                DobroIme = ConfigHelper.GetConfigValue<string>(ConfigFields.NAZIV_DRUSTVA), // prejemnik
                                DobroBIC = ConfigHelper.GetConfigValue<string>(ConfigFields.BIC_BANKE), // bic banke
                                Znesek = 
                                    (
                                        includeDebts
                                        ? (
                                            member.FeeLogs
                                                .Count(
                                                    fl =>
                                                        (ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_OD) == 0 || fl.Year >= ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_OD)) &&
                                                        (ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_DO) == 0 || fl.Year <= ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_DO)) &&
                                                        fl.PaymentStatusID == PaymentStatus.NI_PLACAL
                                                )
                                        )
                                        : (
                                            member.FeeLogs
                                                .Count(
                                                    fl =>
                                                        fl.Year == year &&
                                                        fl.PaymentStatusID == PaymentStatus.NI_PLACAL
                                                )
                                        )
                                    )
                                    *
                                    (
                                        member.Gender
                                        ? ConfigHelper.GetConfigValue<decimal>(ConfigFields.ZNESEK_CLANI)
                                        : ConfigHelper.GetConfigValue<decimal>(ConfigFields.ZNESEK_CLANICE)
                                    ),
                                //DatumPlacila = DateTime.Now.ToString("dd.MM.yyyy"), // rok plačila
                                Namen = String.Format(NAMEN, year), // namen
                                KodaNamena = KODA_NAMENA, // koda namena
                                Member = member, // celotni Member objekt,
                                VrsticaOCR = GenerateControlNumber(dobroSklic)
                            }
                        );
                }
            }

            documentListDataGridView.DataSource = new SortableBindingList<UPNDocument>(docs);

            CreateHeaderCheckBox();
            UnCheckAllRows(false);
            ClearSelection(documentListDataGridView);
            SelectRecords(year, true);
        }

        public string GenerateControlNumber(string sklic)
        {
            var sum = 0;
            var ponder = 2;

            for (int i = sklic.Length - 1; i >= 0; i--)
            {
                var num = int.Parse(sklic[i].ToString());
                sum += ponder * num;
                ponder++;
            }

            var mod = sum % 11;
            var controlNum = 11 - mod;

            if (controlNum >= 10)
                controlNum = 0;

            return sklic + controlNum;
        }

        public void InitializeDataGridView(List<int> years)
        {
            // TODO
        }

        private void SelectRecords(int year, bool includeDebts)
        {
            using (var db = new FeeStatusesDBContext())
            {
                IQueryable<string> idList;

                if (includeDebts)
                {
                    var opominiOdYear = ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_OD);
                    var opominiDoYear = ConfigHelper.GetConfigValue<int>(ConfigFields.OPOMINI_DO);

                    idList = db.Member.
                        Where(m =>
                              m.MustPay &&
                              m.Active &&
                              m.FeeLogs.
                                  Where(fl =>
                                      (opominiOdYear == 0 || fl.Year >= opominiOdYear) &&
                                      (opominiDoYear == 0 || fl.Year <= opominiDoYear)
                                  ).
                                  Any(fl =>
                                      fl.PaymentStatusID == PaymentStatus.NI_PLACAL
                                  )
                        ).
                        Select(m => m.VulkanID);
                }
                else
                {
                    idList = db.Member.
                        Where(m =>
                              m.MustPay &&
                              m.Active &&
                              m.FeeLogs.
                                  Where(fl =>
                                        fl.Year == year
                                  ).
                                  Any(fl =>
                                      fl.PaymentStatusID == PaymentStatus.NI_PLACAL
                                  )
                        ).
                        Select(m => m.VulkanID);
                }

                for (var i = 0; i < documentListDataGridView.Rows.Count; i++)
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
            printContextMenuStrip.Show(printButton, new Point(0, printButton.Height));
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
            if (paperType == PaperType.Laser)
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
            // font za talone
            var talonFont = new Font("Courier New", 7, FontStyle.Regular, GraphicsUnit.Point);

            // font za nalog
            var nalogFont = new Font("Courier New", 12, FontStyle.Regular, GraphicsUnit.Point);

            // font za OCR vrstico
            var ocrFontResource = Properties.Resources.OCR_FONT;
            var ocrFontData = Marshal.AllocCoTaskMem(ocrFontResource.Length);
            Marshal.Copy(ocrFontResource, 0, ocrFontData, ocrFontResource.Length);
            var pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ocrFontData, ocrFontResource.Length);
            Marshal.FreeCoTaskMem(ocrFontData);
            var ocrFontFamily = pfc.Families.First();
            var ocrFont = new Font(ocrFontFamily, 10, FontStyle.Regular, GraphicsUnit.Point);

            Debug.WriteLine("MarginBoundsLeft: " + e.MarginBounds.Left);
            Debug.WriteLine("MarginBoundsTop: " + e.MarginBounds.Top);

            var brush = new SolidBrush(Color.Black);
            var whiteBrush = new SolidBrush(Color.White);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            var farAlign = new StringFormat {Alignment = StringAlignment.Far};

            var farCenterAlign = new StringFormat {Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center};

            var nearAlign = new StringFormat {Alignment = StringAlignment.Near};

            var nearCenterAlign = new StringFormat {Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center};

            UPNDocument docRow;
            for (int i = 0; i < (paperType == PaperType.Laser ? 2 : 3);)
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
                if (paperType == PaperType.Laser)
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

                #region obmocja-ocr

                /* ocr vrstica - 53 znakov */
                var vrsticaOCR = new UPNRectangle(7.76f, 12.32f, 142.38f, 7.02f, UPNFormHeight, UPNTalonMargin, yMargin, xOffset, yOffset);

                #endregion obmocja-ocr

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

                e.Graphics.DrawRectangle(new Pen(whiteBrush, 0.1f), vrsticaOCR.X, vrsticaOCR.Y, vrsticaOCR.Width, vrsticaOCR.Height);

                e.Graphics.DrawString(
                    String.Format(VRSTICA_OCR,
                                  docRow.DobroSklic + "l", // referenca
                                  docRow.DobroIBAN.Substring(10) + "m", // račun
                                  docRow.Znesek.ToString("F").Replace(",", "").Replace(".", "").PadLeft(10, '0') + "n", //znesek
                                  docRow.DobroIBAN.Substring(5) + "000" + "l", // oznaka banke
                                  "56" + "m"), // 'tekst'
                    ocrFont, brush,
                    new RectangleF(vrsticaOCR.X, vrsticaOCR.Y, vrsticaOCR.Width, vrsticaOCR.Height), nearCenterAlign);

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

        private void PrepareDataForSelectedYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectYear = new SelectYearForm();

            if (selectYear.ShowDialog() == DialogResult.OK)
            {
                InitializeDataGridView(selectYear.Year, false);
            }
        }

        private void PrepareDataForSelectedYearRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var allYears = new List<int>();
            using (var db = new FeeStatusesDBContext())
            {
                var feeLogsQuery =
                    db.Member.
                        Where(
                            m =>
                            m.Active &&
                            m.MustPay &&
                            m.FeeLogs.
                                Any(
                                    fl =>
                                    fl.PaymentStatusID == PaymentStatus.NI_PLACAL
                                )
                        ).
                        SelectMany(m => m.FeeLogs);

                allYears = feeLogsQuery.OrderBy(fl => fl.Year).Select(fl => fl.Year).Distinct().ToList();

            }

            var selectYears = new SelectYearRange(allYears);

            if (selectYears.ShowDialog() == DialogResult.OK)
            {
                InitializeDataGridView(selectYears.Years);
            }
        }

        private void PrintUPNDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (documentListDataGridView.Rows.Count < 1)
            {
                MessageBox.Show(WindowMessages.NO_DATA_AVAILABLE_FOR_PRINT, WindowMessages.WARNING_TITLE);
                return;
            }

            var selectedRows = documentListDataGridView.Rows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem).Cast<UPNDocument>().ToList();

            var printAll =
                !selectedRows.Any(x => x.Selected) ||
                selectedRows.Count(x => x.Selected) == documentListDataGridView.Rows.Count;

            if (new PrintFormsSelectionForm(this, printAll).ShowDialog() != DialogResult.OK)
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

        private void PrintStickersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (documentListDataGridView.Rows.Count < 1)
            {
                MessageBox.Show(WindowMessages.NO_DATA_AVAILABLE_FOR_PRINT, WindowMessages.WARNING_TITLE);
                return;
            }

            if (new PrintStickersSelectionForm(this).ShowDialog() != DialogResult.OK)
                return;

            var allRows = documentListDataGridView.Rows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem).Cast<UPNDocument>().ToList();
            var stickersDataSet = allRows.Where(upn => upn.Selected).Select(upn => upn.Member).ToList();

            for (var i = 0; i < stickersToSkip; i++)
            {
                stickersDataSet.Insert(0, new Member());
            }

            var form = ReportViewerForm.GetInstance();

            form.SetReport(
                stickerFormat,
                new ReportDataSource("DataSet1", stickersDataSet),
                new List<ReportParameter>()
            );
        }

        private void BillsWithDebtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeDataGridView(DateTime.Now.Year, true);
        }

        private void OnlyBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeDataGridView(DateTime.Now.Year, false);
        }

        private void CreateHeaderCheckBox()
        {
            var controls = documentListDataGridView.Controls.Find("CheckBoxHeader", true);

            if (controls.Any())
                return;

            var chkBox = new CheckBox();

            var rect = this.documentListDataGridView.GetCellDisplayRectangle(0, -1, true);
            rect.Y = 3;
            rect.X = rect.Location.X + rect.Width / 4 - 2;

            chkBox.Name = "CheckBoxHeader";
            chkBox.Size = new Size(16, 16);
            chkBox.Location = rect.Location;
            chkBox.CheckedChanged += CheckBoxHeader_CheckedChanged;

            this.documentListDataGridView.Controls.Add(chkBox);
            this.documentListDataGridView.Refresh();
        }

        private void CheckBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            var headerBox = ((CheckBox)documentListDataGridView.Controls.Find("CheckBoxHeader", true)[0]);
            UnCheckAllRows(headerBox.Checked);
        }

        private void UnCheckAllRows(bool @checked)
        {
            foreach (DataGridViewRow row in this.documentListDataGridView.Rows)
            {
                var dataRow = row.DataBoundItem as UPNDocument;
                if (dataRow == null)
                    continue;

                dataRow.Selected = @checked;
            }

            this.documentListDataGridView.EndEdit();
            this.documentListDataGridView.Refresh();
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