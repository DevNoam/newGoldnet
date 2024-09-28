using GoldnetWrapper.Core.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace GoldnetWrapper.Core
{
    public class TGMSManager
    {
        /// <summary>
        /// Load basic properties into RegistryVariables
        /// </summary>
        public static void LoadProperties()
        {
            //Check if file exists
            if (!ValidateTGMSPath())
                return;

            RegistryVariables.EDIUsername = GetPropertyKey("tgms-account-mailbox");
            RegistryVariables.downloadThreadsTGMS = int.Parse(GetPropertyKey("download-threads-number"));
        }

        public static bool ValidateTGMSPath()
        {
            if (!File.Exists(Path.Combine(RegistryVariables.TGMSPath, ReadOnlyVariables.appConfig)) || !Directory.Exists(RegistryVariables.TGMSPath))
            {
                MessageBox.Show("TGMS file not found. Validate TGMS Path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }else
            {
                return true;
            }
        }
        /// <summary>
        /// Reset TGMS Database locations for STATAC and PAYEXT
        /// </summary>
        /// <param name="dbPath"></param>
        public static bool SetEDIReceiveLocation(string dbPath)
        {
            dbPath.Replace(@"\", @"\\");
            bool payext = EditAppPropertiesKey("local-dir-service-receive-payext", $@"{dbPath}\\Currency\\In\\");
            bool statac = EditAppPropertiesKey("local-dir-service-receive-statac", $@"{dbPath}\\Mivzaq\\In\\");


            return payext && statac;
        }

        public static string GetPropertyKey(string key)
        {
            var configFilePath = Path.Combine(RegistryVariables.TGMSPath, ReadOnlyVariables.appConfig);
            if (File.Exists(configFilePath))
            {
                // Read the file line by line
                foreach (var line in File.ReadLines(configFilePath))
                {
                    // Split the line into key and value based on the '=' character
                    var parts = line.Split('=');

                    // Check if the line contains both key and value
                    if (parts.Length == 2)
                    {
                        var currentKey = parts[0].Trim();
                        var value = parts[1].Trim();

                        // If the current key matches the provided key, return the value
                        if (currentKey.Equals(key, StringComparison.OrdinalIgnoreCase))
                        {
                            return value;
                        }
                    }
                }
            }

            // Return empty string if the key is not found or file does not exist
            return string.Empty;
        }
        public static bool EditAppPropertiesKey(string key, string value)
        {
            // Get the TGMS path (Assuming RegistryVariables.TGMSPath gives the file path)
            var configFilePath = Path.Combine(RegistryVariables.TGMSPath, ReadOnlyVariables.appConfig);

            // Verify if the file exists
            if (File.Exists(configFilePath))
            {
                // Read all lines from the file into an array
                string[] lines = File.ReadAllLines(configFilePath);

                bool keyFound = false;

                // Open a stream to write the updated lines back
                using (StreamWriter writer = new StreamWriter(configFilePath))
                {
                    foreach (var line in lines)
                    {
                        // Split each line into key and value using the '=' delimiter
                        var parts = line.Split('=');

                        if (parts.Length == 2)
                        {
                            var currentKey = parts[0].Trim();

                            // Check if the current key matches the input key
                            if (currentKey.Equals(key, StringComparison.OrdinalIgnoreCase))
                            {
                                // If the key is found, write the updated key-value pair
                                writer.WriteLine($"{currentKey}={value}");
                                keyFound = true;
                            }
                            else
                            {
                                // Otherwise, write the line as-is
                                writer.WriteLine(line);
                            }
                        }
                        else
                        {
                            // If it's not a key-value pair, write the line as-is
                            writer.WriteLine(line);
                        }
                    }

                    // If the key wasn't found, add it at the end of the file
                    if (!keyFound)
                    {
                        writer.WriteLine($"{key}={value}");
                    }
                }
                // Return true to indicate success
                return true;
            }
            // If the file does not exist, return false
            return false;
        }

        public static void UpdateSSH()
        {
            string tgmsPath = RegistryVariables.TGMSPath;
            Helpers.RunExternalApp(Path.Combine(tgmsPath, "UpdateSSH.bat"));
        }
        public static void OpenTGMSConfig()
        {
            string tgmsPath = RegistryVariables.TGMSPath;
            Helpers.RunExternalApp(Path.Combine(tgmsPath, ReadOnlyVariables.appConfig));
        }
    }
}
