using GoldnetWrapper.Core.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

public class RegistryHelper
{
    private const string DefaultSubKey = "Setup";

    public static void SetValue(string key, object value, string subKey = DefaultSubKey)
    {
        using (var baseKey = Registry.CurrentUser.CreateSubKey($"{ReadOnlyVariables.registryPath}\\{subKey}"))
        {
            if (baseKey != null)
            {
                // Automatically handle DWORD for 0 or 1
                if (value is int intValue && (intValue == 0 || intValue == 1))
                {
                    baseKey.SetValue(key, intValue, RegistryValueKind.DWord);
                }
                else
                {
                    baseKey.SetValue(key, value);
                }
            }
        }
    }

    public static object GetValue(string key, string subKey = DefaultSubKey)
    {
        using (var baseKey = Registry.CurrentUser.OpenSubKey($"{ReadOnlyVariables.registryPath}\\{subKey}", true)) // Open with write access
        {
            if (baseKey == null) return null;

            var value = baseKey.GetValue(key);
            if (value == null)
            {
                SetValue(key, string.Empty, subKey); // Use SetValue to create a default entry
                return string.Empty;
            }

            // Automatically convert DWORD (0 or 1) to boolean
            if (value is int intValue)
            {
                return intValue == 1; // return true or false
            }

            return value; // Return original value for non-integer types
        }
    }

    public static void DeleteValue(string key, string subKey = DefaultSubKey)
    {
        using (var baseKey = Registry.CurrentUser.OpenSubKey($"{ReadOnlyVariables.registryPath}\\{subKey}", true))
        {
            if (baseKey != null)
            {
                baseKey.DeleteValue(key, false);
            }
        }
    }

    public static Dictionary<string, object> GetAllValues(string subKey = DefaultSubKey)
    {
        var values = new Dictionary<string, object>();
        using (var baseKey = Registry.CurrentUser.OpenSubKey($"{ReadOnlyVariables.registryPath}\\{subKey}"))
        {
            if (baseKey != null)
            {
                foreach (var valueName in baseKey.GetValueNames())
                {
                    values[valueName] = baseKey.GetValue(valueName);
                }
            }
        }
        return values;
    }

    public static void WriteFromDictionary(Dictionary<string, object> values, string subKey = DefaultSubKey)
    {
        foreach (var kvp in values)
        {
            SetValue(kvp.Key, kvp.Value, subKey);
        }
    }

    /// <summary>
    /// Loads all the variables from the registry into RegistryVariables class
    /// </summary>
    public static void LoadVariables()
    {
        RegistryVariables.DatabaseDir = RegistryHelper.GetValue("DatabaseDir").ToString();
        RegistryVariables.TGMSPath = RegistryHelper.GetValue("TGMSPath").ToString();
        RegistryVariables.RawCurrencyDir = RegistryHelper.GetValue("RawCurrencyDir").ToString();
        //Read 1 or 0 from registry and convert to bool
        RegistryVariables.CheckBalance = Convert.ToInt32(RegistryHelper.GetValue("CheckBalance")) == 1 ? true : false;
        RegistryVariables.BackupExport = Convert.ToInt32(RegistryHelper.GetValue("BackupExport")) == 1 ? true : false;
        RegistryVariables.RawExportECurency = Convert.ToInt32(RegistryHelper.GetValue("RawExportECurency")) == 1 ? true : false;
        RegistryVariables.AutoFetchData = Convert.ToInt32(RegistryHelper.GetValue("AutoFetchData")) == 1 ? true : false;
    }
}
