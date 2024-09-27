using GoldnetWrapper.Core.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

public class RegistryHelper
{

    // Create or Update a registry key/value
    // Create or Update a registry key/value
    public static void SetValue(string key, object value)
    {
        using (var baseKey = Registry.CurrentUser.CreateSubKey(ReadOnlyVariables.registryPath))
        {
            if (baseKey != null)
            {
                baseKey.SetValue(key, value);
            }
        }
    }

    // Read a registry key/value and create a default value if it doesn't exist
    public static object GetValue(string key)
    {
        using (var baseKey = Registry.CurrentUser.OpenSubKey(ReadOnlyVariables.registryPath, true)) // Open with write access
        {
            if (baseKey != null)
            {
                var value = baseKey.GetValue(key);

                // If the value is null, create a default value
                if (value == null)
                {
                    // Assuming default values:
                    // - string: empty
                    // - int: 0
                    // - bool: false
                    object defaultValue = string.Empty; // Default for string type
                    baseKey.SetValue(key, defaultValue); // Set default value in the registry
                    return defaultValue; // Return the default value
                }
                return value; // Return the existing value
            }
        }
        return null; // Return null if the key does not exist
    }

    // Delete a registry key/value
    public static void DeleteValue(string key)
    {
        using (var baseKey = Registry.CurrentUser.OpenSubKey(ReadOnlyVariables.registryPath, true))
        {
            if (baseKey != null)
            {
                baseKey.DeleteValue(key, false);
            }
        }
    }

    // Get all registry values as a Dictionary
    public static Dictionary<string, object> GetAllValues()
    {
        var values = new Dictionary<string, object>();
        using (var baseKey = Registry.CurrentUser.OpenSubKey(ReadOnlyVariables.registryPath))
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

    // Read from a Dictionary and write to registry
    public static void WriteFromDictionary(Dictionary<string, object> values)
    {
        foreach (var kvp in values)
        {
            SetValue(kvp.Key, kvp.Value);
        }
    }
}
