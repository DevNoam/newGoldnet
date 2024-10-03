using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldnetWrapper.Core.Properties
{
    internal class ReadOnlyVariables
    {
        public readonly static string bezeqIntWebsite = "https://bezeqint.net/";
        public readonly static string newsJsonWebsite = "https://api.noamsapir.me/bezeqint/multibill/news.json";
        public readonly static string selfServicePortal = "https://bezeqint.net/MultiBill";
        public readonly static string supportPhone = "1-700-555-222";
        public readonly static string supportEmail = "ITServicesA@bezeqint.co.il";
        public readonly static string registryPath = @"Software\Goldnet\Setup";
        public readonly static string appConfig = "app.properties";
        public static string tgms_address = "1.1.1.1";
        public static int tgms_port = 22;
        public static string logName = "fetchLog.txt";
        public static string repsConfig = "gnexport.ini";
    }
}
