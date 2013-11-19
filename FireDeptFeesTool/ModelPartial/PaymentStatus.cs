namespace FireDeptFeesTool.Model
{
    partial class PaymentStatus
    {
        #region Payment status values

        public const int PLACAL = 1;
        public const int NI_PLACAL = 2;
        public const int VETERAN = 3;
        public const int MLADOLETNIK = 4;
        public const int NI_PODATKA = 5;

        #endregion

        #region Payment status descriptions

        public const string PLACAL_DESC = "";
        public const string NI_PLACAL_DESC = "";
        public const string VETERAN_DESC = "Starost člana >= 60 let.";
        public const string MLADOLETNIK_DESC = "Starost člana < 18 let.";
        public const string NI_PODATKA_DESC = "";

        #endregion

        public static string GetPaymentStatusDesc(int? value)
        {
            switch (value)
            {
                case 1:
                    return PLACAL_DESC;
                case 2:
                    return NI_PLACAL_DESC;
                case 3:
                    return VETERAN_DESC;
                case 4:
                    return MLADOLETNIK_DESC;
                case 5:
                    return NI_PODATKA_DESC;
                default:
                    return "";
            }
        }
    }
}