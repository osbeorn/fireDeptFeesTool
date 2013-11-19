using System;

namespace FireDeptFeesTool.Lib
{
    public class UPNDocument
    {
        public UPNDocument(string[] data)
        {
            Selected = false;
            TipDokumenta = data[0];
            BremeIBAN = data[1];
            BremeModel = data[2];
            BremeSklic = data[3];
            BremeIme = data[4];
            DobroIBAN = data[5];
            DobroModel = data[6];
            DobroSklic = data[7];
            DobroIme = data[8];
            DobroBIC = data[9];
            Znesek = Convert.ToDecimal(data[10]);
            DatumPlacila = data[11];
            Namen = data[12];
            KodaNamena = data[13];
            Nujno = false;
            Izjava = false;
            ObvezenVnosVsehPolj = false;
            PreveriKontrolneStevilke = false;
            SamodejnoPripraviOCR = false;
        }

        public bool Selected { get; set; }
        public string TipDokumenta { get; set; }
        public string BremeIBAN { get; set; }
        public string BremeModel { get; set; }
        public string BremeSklic { get; set; }
        public string BremeIme { get; set; }
        public string DobroIBAN { get; set; }
        public string DobroModel { get; set; }
        public string DobroSklic { get; set; }
        public string DobroIme { get; set; }
        public string DobroBIC { get; set; }
        public decimal Znesek { get; set; }
        public string DatumPlacila { get; set; }
        public string Namen { get; set; }
        public string KodaNamena { get; set; }
        public bool Nujno { get; set; }
        public bool Izjava { get; set; }
        public bool ObvezenVnosVsehPolj { get; set; }
        public bool PreveriKontrolneStevilke { get; set; }
        public bool SamodejnoPripraviOCR { get; set; }
    }
}