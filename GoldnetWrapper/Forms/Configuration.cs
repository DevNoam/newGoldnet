using GoldnetWrapper.Core;
using GoldnetWrapper.Core.Properties;
using GoldnetWrapper.Core.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GoldnetWrapper.Forms
{
    public partial class Configuration : Form
    {
        RepManager repManager;
        RegistryHelper registryHelper;
        RegistryVariables registryVariables = new RegistryVariables();
        public Configuration()
        {
            InitializeComponent();
            LoadSettings();


            ListenToChanges();
        }

        private void LoadSettings()
        { 
            repManager = new RepManager();
            registryHelper = new RegistryHelper();
            DisplayReps();

            registryVariables.DatabaseDir = RegistryHelper.GetValue("DatabaseDir").ToString();
            registryVariables.TGMSPath = RegistryHelper.GetValue("TGMSPath").ToString();
            //Read 1 or 0 from registry and convert to bool
            registryVariables.CheckBalance = RegistryHelper.GetValue("CheckBalance").ToString() == "1" ? true : false;
            registryVariables.BackupExport = RegistryHelper.GetValue("BackupExport").ToString() == "1" ? true : false;
            registryVariables.RawExportECurency = RegistryHelper.GetValue("RawExportECurency").ToString() == "1" ? true : false;
            registryVariables.RawCurrencyDir = RegistryHelper.GetValue("RawCurrencyDir").ToString();
            registryVariables.UserName = RegistryHelper.GetValue("UserName").ToString();
            
            //Write values to the form
            dbPath.Text = registryVariables.DatabaseDir;
            tgmsPath.Text = registryVariables.TGMSPath;
            checkBalance.Checked = registryVariables.CheckBalance;
            backupExportFiles.Checked = registryVariables.BackupExport;
            exportMatah.Checked = registryVariables.RawExportECurency;
            matahFile.Text = registryVariables.RawCurrencyDir;
            EDIBoxID.Text = registryVariables.UserName;

            enableMatahPath();
        }
        private void SaveSettings()
        {
            string DatabaseDir = dbPath.Text;
            string TGMSPath = tgmsPath.Text;
            bool CheckBalance = checkBalance.Checked;
            bool BackupExport = backupExportFiles.Checked;
            bool RawExportECurency = exportMatah.Checked;
            string RawCurrencyDir = matahFile.Text;
            string UserName = EDIBoxID.Text;

            if(DatabaseDir != registryVariables.DatabaseDir)
                RegistryHelper.SetValue("DatabaseDir", DatabaseDir);
            if(TGMSPath != registryVariables.TGMSPath)
                RegistryHelper.SetValue("TGMSPath", TGMSPath);
            if(CheckBalance != registryVariables.CheckBalance)
                RegistryHelper.SetValue("CheckBalance", (bool)CheckBalance ? "1" : "0");
            if(BackupExport != registryVariables.BackupExport)
                RegistryHelper.SetValue("BackupExport", (bool)BackupExport ? "1" : "0");
            if(RawExportECurency != registryVariables.RawExportECurency)
                RegistryHelper.SetValue("RawExportECurency", (bool)RawExportECurency ? "1" : "0");
            if(RawCurrencyDir != registryVariables.RawCurrencyDir)
                RegistryHelper.SetValue("RawCurrencyDir", RawCurrencyDir);
            if(UserName != registryVariables.UserName)
                RegistryHelper.SetValue("UserName", UserName);
            MessageBox.Show("Saved");
        }

        private void DisplayReps()
        {
            RepData[] disabledReps = repManager.GetDisabledReps();
            RepData[] enabledReps = repManager.GetEnabledReps();

            foreach (var rep in disabledReps)
            {
                RepSelector repObject = new RepSelector();
                repObject.InitRep(rep);
                disabledRepsPanel.Controls.Add(repObject);
            }
            foreach (var rep in enabledReps)
            {
                RepSelector repObject = new RepSelector();
                repObject.InitRep(rep);
                enabledRepsPanel.Controls.Add(repObject);
            }
        }

        private void ListenToChanges()
        { 
            //Listen to App.Properties changes
            //Listen to RepBank folder changes
            //Listen to MainFolder changes
        }
        


        private void updateSSH_Click(object sender, EventArgs e) => TGMSManager.UpdateSSH();

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
            SaveFileDialog dialog = new SaveFileDialog();
            matahFile.Text = string.Empty;
        }

        private void enableMatahPath()
        {
            if (exportMatah.Checked)
            {
                matahFile.Enabled = true;
            }
            else
            {
                matahFile.Enabled = false;
            }
        }

        private void exportMatah_CheckedChanged(object sender, EventArgs e) => enableMatahPath();
        private void openExportWizard_Click(object sender, EventArgs e) => Helpers.RunExternalApp(Path.Combine(Application.StartupPath, "ExportWizard.bat"));

        private void tgmsAppProperties_Click(object sender, EventArgs e) => TGMSManager.OpenTGMSConfig();
        private void SaveButton_Click(object sender, EventArgs e) => SaveSettings();
    }
}
