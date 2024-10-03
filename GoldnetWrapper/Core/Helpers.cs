using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System;
using System.Linq;

namespace GoldnetWrapper.Core
{
    static class Helpers
    {
        public static void OpenURL(string url) => Process.Start(url);
        public static void CloseApplication() => Application.Exit();
        public static void RunExternalApp(string path)
        {
            try
            {
                Process appProcess = new Process();
                appProcess.StartInfo.FileName = path;
                appProcess.Start();
            }
            catch (Exception ex) // Catch any exceptions, like file not found
            {
                MessageBox.Show($"Failed to start {Path.GetFileName(path)}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UpdateStatus(string message) => Main.StatusLabelVar.Text = message;

        public static bool isProcessRunning(string name)
        {
            try
            {
                Process.GetProcessesByName(name);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }
        public static bool killProcess(string name)
        {
            try
            {
                Process.GetProcessesByName(name).ToList().ForEach(p => p.Kill());
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidPath(string path)
        {
            // Check if the path is not null, empty, or contains invalid characters
            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            try
            {
                // Check if the path contains invalid characters
                string fullPath = Path.GetFullPath(path);

                // Check if the path has a valid root
                string root = Path.GetPathRoot(fullPath);
                if (string.IsNullOrEmpty(root.Trim()))
                {
                    return false;
                }

                return true; // The path is valid
            }
            catch (Exception)
            {
                // If any exception is thrown (e.g., invalid format), the path is invalid
                return false;
            }
        }
    }
}
