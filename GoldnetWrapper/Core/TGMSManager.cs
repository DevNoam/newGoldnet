using System.IO;

namespace GoldnetWrapper.Core
{
    public class TGMSManager
    {
        public static string tgmsConfigInstance;
        string GetProperty(string key)
        {

            //GET TGMS PATH,
            // LOAD APP.PROPERTIES



            //GET VALUE
            // RETURN VALUE
            //CLOSE STREAM
            return string.Empty;
        }
        bool EditAppProperties(string key, string value)
        {
            //GET TGMS PATH,
            // LOAD APP.PROPERTIES



            //EDIT VALUE
            // SAVE
            //CLOSE STREAM
            return false;
        }
        public static void UpdateSSH()
        { 
            throw new System.NotImplementedException();
        }
        public static void OpenTGMSConfig()
        {
            //GET TGMS PATH
            string tgmsPath = RegistryHelper.GetValue("TGMSPath").ToString();

            Helpers.RunExternalApp(Path.Combine(tgmsPath, "app.properties"));

            // REMEMBER PROCESS ID (TO AVOID REOPENING)
            // WAIT FOR PROCESS TO CLOSE
            // WHEN CLOSED, UPDATE SETTINGS FORM WITH NEW VALUES, IF ANY CHANGES.
        }
    }
}
