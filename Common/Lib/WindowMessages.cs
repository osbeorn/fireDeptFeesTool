namespace FireDeptFeesTool.Common.Lib
{
    public class WindowMessages
    {
        #region messages

        public const string STORED_DATA_EXISTS_MSG =
            "Podatki o {0} že obstajajo. Če boste nadaljevali z uvozom, tvegate možnost, da boste prepisali obstoječe podatke z novimi. Ste prepričani, da želite nadaljevati?";

        public const string SAVE_OR_DISCARD_CHANGES_MSG =
            "Obstajajo spremembe.\nJih želite shraniti?";

        public const string RECORDS_FOR_YEAR_EXIST_MSG =
            "Zapisi za izbrano leto {0} že obstajajo,\nzato stolpec ne bo dodan.";

        public const string IMPORT_DATA_CONFIRMATION_REQUIRED_MSG =
            "Ste prepričani, da želite uvoziti podatke iz datoteke \"{0}\"?";

        public const string NO_DATA_AVAILABLE_FOR_PRINT =
            "Ni podatkov za tiskanje.";

        #endregion messages

        #region titles

        public const string STORED_DATA_EXISTS_TITLE = "Obstoječi podatki";
        public const string SAVE_OR_DISCARD_CHANGES_TITLE = "Spremembe";
        public const string RECORDS_FOR_YEAR_EXIST_TITLE = "Obstajajo zapisi";
        public const string IMPORT_DATA_TITLE = "Uvoz podatkov";
        public const string WARNING_TITLE = "Opozorilo";

        #endregion titles
    }
}