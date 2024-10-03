namespace GoldnetWrapper.Core.Properties
{
    public class RepData
    {
        public int repId { get; set; } //ID of the rep in the gpexport file
        public string repName { get; set; } // Name of the rep file
        public string OutputFolder { get; set; } // Full path and file name
        public int Enabled { get; set; } // 1 enabled, 0 disabled
    }
}
