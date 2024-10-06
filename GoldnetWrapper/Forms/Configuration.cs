using GoldnetWrapper.Core;
using GoldnetWrapper.Core.Properties;
using GoldnetWrapper.Core.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace GoldnetWrapper.Forms
{
    public partial class Configuration : Form
    {
        private RepManager repManager;

        private FileSystemWatcher configWatcher;
        private FileSystemWatcher folderWatcher;
        public Configuration()
        {
            InitializeComponent();
            repManager = new RepManager(enabledRepsPanel, disabledRepsPanel);

            repManager.LoadReps();

            LoadSettings();
            StartWatchers();
            this.FormClosing += ConfigClose;
        }
        private void ConfigClose(object sender, FormClosingEventArgs e)
        {
            if (configWatcher != null) configWatcher.Dispose();
            if (folderWatcher != null) folderWatcher.Dispose();
        }

        private void LoadSettings()
        {
            RegistryHelper.LoadVariables();
            TGMSManager.LoadProperties();


            //Write values to the form
            dbPath.Text = RegistryVariables.DatabaseDir;
            tgmsPath.Text = RegistryVariables.TGMSPath;
            checkBalance.Checked = RegistryVariables.CheckBalance;
            backupExportFiles.Checked = RegistryVariables.BackupExport;
            exportMatah.Checked = RegistryVariables.RawExportECurency;
            matahFile.Text = RegistryVariables.RawCurrencyDir;
            EDIBoxID.Text = RegistryVariables.EDIUsername;
            AutoFetchData.Checked = RegistryVariables.AutoFetchData;
            downloadThreadsTGMS.Value = RegistryVariables.downloadThreadsTGMS < downloadThreadsTGMS.Minimum ? downloadThreadsTGMS.Minimum :
                                         (RegistryVariables.downloadThreadsTGMS > downloadThreadsTGMS.Maximum ? downloadThreadsTGMS.Maximum :
                                         RegistryVariables.downloadThreadsTGMS);
            enableMatahPath();
        }

        private void SaveSettings()
        {
            dbPath.Text = string.IsNullOrWhiteSpace(dbPath.Text) ? string.Empty : Regex.Replace(dbPath.Text.Replace(" ", "").TrimEnd('\\'), @"\\{2,}", @"\"); string DatabaseDir = dbPath.Text;
            string TGMSPath = tgmsPath.Text;
            bool CheckBalance = checkBalance.Checked;
            bool BackupExport = backupExportFiles.Checked;
            bool RawExportECurency = exportMatah.Checked;
            bool AutoFetchData = this.AutoFetchData.Checked;
            string RawCurrencyDir = matahFile.Text;
            int DownloadThreads = Convert.ToInt32(downloadThreadsTGMS.Value);

            int changesMade = 0;
            if (tgmsPath.Text != RegistryVariables.TGMSPath)
            {
                RegistryHelper.SetValue("TGMSPath", TGMSPath);
                changesMade++;
            }
            if (dbPath.Text != RegistryVariables.DatabaseDir)
            {
                RegistryHelper.SetValue("DatabaseDir", DatabaseDir);
                TGMSManager.SetEDIReceiveLocation(DatabaseDir);
                changesMade++;
            }
            if (DownloadThreads != RegistryVariables.downloadThreadsTGMS)
            {
                if (TGMSManager.EditAppPropertiesKey("download-threads-number", DownloadThreads.ToString()))
                { 
                    RegistryVariables.downloadThreadsTGMS = DownloadThreads;
                    changesMade++;
                }
            }
            if (CheckBalance != RegistryVariables.CheckBalance)
            { 
                RegistryHelper.SetValue("CheckBalance", (bool)CheckBalance ? "1" : "0");
                changesMade++;
            }
            if (BackupExport != RegistryVariables.BackupExport)
            { 
                RegistryHelper.SetValue("BackupExport", (bool)BackupExport ? "1" : "0");
                changesMade++;
            }
            if (RawExportECurency != RegistryVariables.RawExportECurency)
            { 
                RegistryHelper.SetValue("RawExportECurency", (bool)RawExportECurency ? "1" : "0");
                changesMade++;
            }
            if (RawCurrencyDir != RegistryVariables.RawCurrencyDir)
            { 
                RegistryHelper.SetValue("RawCurrencyDir", RawCurrencyDir);
                changesMade++;
            }
            if (AutoFetchData != RegistryVariables.AutoFetchData)
            { 
                RegistryHelper.SetValue("AutoFetchData", (bool)AutoFetchData ? "1" : "0");
                changesMade++;
            }

            if(changesMade > 0)
            {
                //Reload the regedit vars to the RegistryVariables class.
                RegistryHelper.LoadVariables();
            }
            repManager.SaveReps();
            this.Close();
        }


        private void StartWatchers()
        {
            Task.Run(() =>
            {
                // Start the config file watcher
                StartConfigWatcher();
            });
        }

        private void StartConfigWatcher()
        {
            if (System.IO.File.Exists(Path.Combine(RegistryVariables.TGMSPath, ReadOnlyVariables.appConfig)))
            {
                using (var configWatcher = new FileSystemWatcher(RegistryVariables.TGMSPath, ReadOnlyVariables.appConfig))
                {
                    configWatcher.NotifyFilter = NotifyFilters.LastWrite;
                    configWatcher.Changed += (sender, e) => InvokeSafely(TGMSConfChanged);
                    configWatcher.EnableRaisingEvents = true;

                    // Keep this task running while watching for changes
                    while (true)
                    {
                        Thread.Sleep(100); // Prevent task from exiting
                    }
                }
            }

            MessageBox.Show("TGMS app.properties not found!");
            return;
        }

        /// <summary>
        /// Invoke using the UI Thread
        /// </summary>
        /// <param name="action"></param>
        private void InvokeSafely(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void TGMSConfChanged()
        {
            TGMSManager.LoadProperties(); // Reload properties

            // Update UI controls
            if (EDIBoxID.Text != RegistryVariables.EDIUsername)
                EDIBoxID.Text = RegistryVariables.EDIUsername;

            if (Convert.ToInt32(downloadThreadsTGMS.Value) != RegistryVariables.downloadThreadsTGMS)
                downloadThreadsTGMS.Value = RegistryVariables.downloadThreadsTGMS < downloadThreadsTGMS.Minimum ? downloadThreadsTGMS.Minimum :
                                             (RegistryVariables.downloadThreadsTGMS > downloadThreadsTGMS.Maximum ? downloadThreadsTGMS.Maximum :
                                             RegistryVariables.downloadThreadsTGMS);
        }

        private void OpentgmsFolder(object sender, EventArgs e) => TGMSManager.OpentgmsFolder();

        private void dbPathSelect_Click(object sender, EventArgs e)
        {
            //open folder select;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.RootFolder = dbPath.Text == string.Empty ? Environment.SpecialFolder.Desktop : Environment.SpecialFolder.Desktop;
            dialog.Description = "בחר בסיס נתונים";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dbPath.Text = dialog.SelectedPath;
                dialog.Dispose();
            }

            //If path has no childs, ask user if he wants to create a new db


        }

        private void tgmsPathSelect_Click(object sender, EventArgs e)
        {
            //open folder select;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            dialog.RootFolder = tgmsPath.Text == string.Empty ? Environment.SpecialFolder.Desktop : Environment.SpecialFolder.Desktop;
            dialog.Description = "Select TGMS folder";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tgmsPath.Text = dialog.SelectedPath;
            }
            dialog.Dispose();
        }

        private void selectMatahFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Select currency export file";
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|Data files (*.dat)|*.dat|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "dat"; // Set default extension
                saveFileDialog.FileName = "raw";

                // Show the dialog and check if the user clicked OK
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    matahFile.Text = saveFileDialog.FileName;
                }
            }
        }

        private void enableMatahPath()
        {
            if (exportMatah.Checked)
            {
                matahFile.Enabled = true;
                selectMatahFile.Enabled = true;
            }
            else
            {
                matahFile.Enabled = false;
                selectMatahFile.Enabled = false;
            }
        }
        #region form_buttons
        private void exportMatah_CheckedChanged(object sender, EventArgs e) => enableMatahPath();
        private void openExportWizard_Click(object sender, EventArgs e) => Helpers.RunExternalApp(Path.Combine(Application.StartupPath, "ExportWizard.bat"));

        private void tgmsAppProperties_Click(object sender, EventArgs e) => TGMSManager.OpenTGMSConfig();
        private void SaveButton_Click(object sender, EventArgs e) => SaveSettings();
        #endregion

        private void openRepImportPath_Click(object sender, EventArgs e)
        {
            //Open the dir 
            Helpers.RunExternalApp(Application.StartupPath);
        }
    }
}
