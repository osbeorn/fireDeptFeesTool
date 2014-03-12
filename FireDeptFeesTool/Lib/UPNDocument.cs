using System;

namespace FireDeptFeesTool.Lib
{
    public class UPNDocument
    {
        public bool Selected { get; set; }
        //public string TipDokumenta { get; set; }
        //public string BremeIBAN { get; set; }
        //public string BremeModel { get; set; }
        //public string BremeSklic { get; set; }
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
        //public bool Nujno { get; set; }
        //public bool Izjava { get; set; }
        //public bool ObvezenVnosVsehPolj { get; set; }
        //public bool PreveriKontrolneStevilke { get; set; }
        //public bool SamodejnoPripraviOCR { get; set; }
    }
}