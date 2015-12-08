using System;
using System.Globalization;

namespace FireDeptFeesTool.Common.Lib
{
    public class BankExportDocument
    {
        public BankExportDocument(string data)
        {
            ParseDataLine(data);
        }

        public string RacunPartnerja { get; set; }
        public string OznakaKnjizenja { get; set; }
        public DateTime DatumObdelave { get; set; }
        public bool StornoPrometa { get; set; }
        public string NazivKomitenta { get; set; }
        public string NacinIzvrsitve { get; set; }
        public DateTime DatumPlacila { get; set; }
        public string RacunKomitenta { get; set; }
        public Decimal Znesek { get; set; }
        public string OznakaVrstePosla { get; set; }
        public string SifraIzdatka { get; set; }
        public string SifraPrejemka { get; set; }
        public string ModelObrementive { get; set; }
        public string SklicObremenitve { get; set; }
        public string ModelOdobritve { get; set; }
        public string SklicOdobritve { get; set; }
        public string Namen { get; set; }
        public string KrajPartnerja { get; set; }
        public string NazivPartnerja { get; set; }
        public string OznakaTransakcije { get; set; }
        public string RacunPrejemnika { get; set; }

        private void ParseDataLine(string data)
        {
            RacunPartnerja = data.Substring(0, 18).Trim();
            OznakaKnjizenja = data.Substring(18, 2).Trim();
            DatumObdelave = DateTime.ParseExact(data.Substring(20, 8), "dd.MM.yy", CultureInfo.InvariantCulture);
            StornoPrometa = data.Substring(28, 2).Trim() == "S";
            NazivKomitenta = data.Substring(30, 35).Trim();
            NacinIzvrsitve = data.Substring(65, 1).Trim();
            DatumPlacila = DateTime.ParseExact(data.Substring(66, 6), "ddMMyy", CultureInfo.InvariantCulture);
            RacunKomitenta = data.Substring(72, 18).Trim();
            Znesek = CustomParseDecimal(data.Substring(90, 15).Trim());
            OznakaVrstePosla = data.Substring(106, 1).Trim();
            SifraIzdatka = data.Substring(107, 2).Trim();
            SifraPrejemka = data.Substring(109, 2).Trim();
            ModelObrementive = data.Substring(111, 2).Trim();
            SklicObremenitve = data.Substring(113, 22).Trim();
            ModelOdobritve = data.Substring(135, 2).Trim();
            SklicOdobritve = data.Substring(137, 22).Trim();
            Namen = data.Substring(159, 36).Replace('^', 'Č').Replace('[', 'Š').Replace('@', 'Ž').Trim();
            KrajPartnerja = data.Substring(195, 10).Replace('^', 'Č').Replace('[', 'Š').Replace('@', 'Ž').Trim();
            NazivPartnerja = data.Substring(205, 35).Replace('^', 'Č').Replace('[', 'Š').Replace('@', 'Ž').Trim();
            OznakaTransakcije = data.Substring(240, 22).Trim();
            RacunPrejemnika = data.Substring(262, 18).Trim();
        }

        private Decimal CustomParseDecimal(string value)
        {
            string tmpValue = value.Insert(value.Length - 2, ",");
            return Decimal.Parse(tmpValue);
        }
    }
}