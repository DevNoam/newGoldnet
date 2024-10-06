using GoldnetWrapper.Core.Properties;
using System;
using System.IO;
using System.Linq;
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
            dbPath = dbPath.Replace("\\", "\\\\"); // Replace single backslashes with double backslashes
            Console.WriteLine(dbPath);
            bool payext = EditAppPropertiesKey("local-dir-service-receive-payext", $@"{dbPath}\\Currency\\In\\");
            bool statac = EditAppPropertiesKey("local-dir-service-receive-statac", $@"{dbPath}\\Mivzaq\\In\\");

            return payext && statac;
        }

        public static string GetPropertyKey(string key)
        {
            var configFilePath = Path.Combine(RegistryVariables.TGMSPath, ReadOnlyVariables.appConfig);
            if (File.Exists(configFilePath))
            {
                // Using a StreamReader to ensure proper disposal
                using (var reader = new StreamReader(configFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
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
            }

            // Return empty string if the key is not found or file does not exist
            return string.Empty;
        }

        public static bool EditAppPropertiesKey(string key, string value)
        {
            var configFilePath = Path.Combine(RegistryVariables.TGMSPath, ReadOnlyVariables.appConfig);

            // Verify if the file exists
            if (!File.Exists(configFilePath))
            {
                return false; // Return false if the file does not exist
            }

            string[] lines;
            try
            {
                // Read all lines from the file into a list
                lines = File.ReadAllLines(configFilePath);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return false; // Return false if there's an issue reading the file
            }

            bool keyFound = false;

            // Create a temporary file path
            string tempFilePath = configFilePath + ".tmp";

            try
            {
                using (var writer = new StreamWriter(tempFilePath))
                {
                    foreach (var line in lines)
                    {
                        // Split each line into key and value
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

                // Replace the original file with the updated temp file
                File.Delete(configFilePath);
                File.Move(tempFilePath, configFilePath);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
                return false; // Return false if there's an issue writing to the file
            }
            finally
            {
                // Clean up: Delete the temporary file if it exists
                if (File.Exists(tempFilePath))
                {
                    try
                    {
                        File.Delete(tempFilePath);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Error deleting temp file: {ex.Message}");
                    }
                }
            }

            return true; // Return true to indicate success
        }

        public static void OpentgmsFolder()
        {
            string tgmsPath = RegistryVariables.TGMSPath;
            Helpers.RunExternalApp(tgmsPath);
        }
        public static void OpenTGMSConfig()
        {
            string tgmsPath = RegistryVariables.TGMSPath;
            Helpers.RunExternalApp(Path.Combine(tgmsPath, ReadOnlyVariables.appConfig));
        }
    }
}
