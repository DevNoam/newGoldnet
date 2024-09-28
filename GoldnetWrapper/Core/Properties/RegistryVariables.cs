namespace GoldnetWrapper.Core.Properties
{
    public class RegistryVariables
    {
        public static string TGMSPath { get; set; }
        public static string DatabaseDir { get; set; }
        public static bool CheckBalance { get; set; }
        public static bool BackupExport { get; set; }
        public static bool RawExportECurency { get; set; }
        public static string RawCurrencyDir { get; set; }
        public static bool AutoFetchData { get; set; }

        //TGMS Variables:
        public static string EDIUsername { get; set; }
        public static int downloadThreadsTGMS { get; set; }
    }
}
