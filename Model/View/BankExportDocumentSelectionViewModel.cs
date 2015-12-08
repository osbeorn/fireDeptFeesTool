namespace FireDeptFeesTool.Model.View
{
    public class BankExportDocumentSelectionViewModel
    {
        public string Member { get; set; }
        public string BankDocData { get; set; }
        public string Years { get; set; } // comma separated list of years
        public bool Warning { get; set; }
        public bool Selected { get; set; }
    }
}