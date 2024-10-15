using GoldnetWrapper.Core;
using GoldnetWrapper.Core.Properties;
using GoldnetWrapper.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace GoldnetWrapper
{
    public partial class Main : Form
    {
        public static Label StatusLabelVar;
        bool isFetching = false;
        Process batchProcess = new Process();
        string logFilePath = Path.Combine(Application.StartupPath, ReadOnlyVariables.logName);


        public Main()
        {
            InitializeComponent();
            StatusLabelVar = this.StatusLabel;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayWelcomeHeader();

            ReadNews();
            if(RegistryVariables.AutoFetchData)
                FetchData();
        }
        private void DisplayWelcomeHeader()
        {
            //if time is morning
            if (DateTime.Now.Hour < 12)
                WelcomeHeader.Text = $"בוקר טוב,";
            //if time is afternoon
            else if (DateTime.Now.Hour < 17)
                WelcomeHeader.Text = $"צהריים טובים,";
            //if time is evening
            else
                WelcomeHeader.Text = $"ערב טוב,";
        }

        private void Logo_Click(object sender, EventArgs e) => Helpers.OpenURL(ReadOnlyVariables.bezeqIntWebsite);

        private void ExitApp_Click(object sender, EventArgs e)
        {
            //Find go.bat and kill it
            batchProcess.Kill();
            Helpers.CloseApplication();
        }

        private void GetSupport_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            support.ShowDialog();
        }

        private void OpenSettingsButton_Click(object sender, EventArgs e) => OpenSettingsForm();
        private void OpenSettings_Click(object sender, EventArgs e) => OpenSettingsForm();

        private void OpenSettingsForm()
        {
            using (Configuration configuration = new Configuration()) // Using block to ensure disposal
            {
                configuration.FormClosed += SettingsClosed;
                configuration.ShowDialog();
                configuration.FormClosed -= SettingsClosed; // Detach event handler after dialog closes
            }
        }
        private void SettingsClosed(object sender, FormClosedEventArgs e) => DisplayWelcomeHeader();


        [Obsolete]
        private void OpenExports_Click(object sender, EventArgs e)
        {
            //Find the last export path
            //Open the file explorer
        }

        private void ReFetch_Data_Click(object sender, EventArgs e) 
        { 
            ReadNews();
            FetchData();
        }

        private void FetchData()
        {
            //Disable buttons
            LogMessage($"Log started: {DateTime.Now}", false);


            ChangeButtonsState(false);
            // Step 1: Start the batch file process
            System.Timers.Timer timeoutTimer;
            batchProcess.StartInfo.FileName = Path.Combine(Application.StartupPath, "go.bat");
            batchProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            batchProcess.StartInfo.CreateNoWindow = true;
            batchProcess.StartInfo.UseShellExecute = false;
            batchProcess.StartInfo.RedirectStandardOutput = true;
            batchProcess.StartInfo.RedirectStandardError = true;
            batchProcess.EnableRaisingEvents = true;
            batchProcess.Exited += (sender, e) =>
            {
                // Ensure we update the UI on the main thread
                this.Invoke(new Action(() => ChangeButtonsState(true)));
            };

            bool isFetchingEnded = false;
            bool displayTGMSLogs = false;
            int timeoutInterval = 5000;


            // Timer to detect inactivity
            timeoutTimer = new System.Timers.Timer(timeoutInterval);
            timeoutTimer.Elapsed += (sender, e) =>
            {
                if (!isFetchingEnded && !batchProcess.HasExited && !StatusLabel.Text.Contains("Importing Mivzaq") && !StatusLabel.Text.Contains("Importing Matah"))
                {
                    batchProcess.Kill();
                    timeoutTimer.Stop();
                    ShowTimeoutError();
                }
            };
            timeoutTimer.AutoReset = false;


            // Step 2 & 3: Handle output lines (StandardOutput)
            batchProcess.OutputDataReceived += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    // Reset timer if output is received
                    timeoutTimer.Stop();
                    timeoutTimer.Start();


                    if (e.Data.Contains("TGMS"))
                    {
                        if (e.Data.Contains("STARTTGMS"))
                        { 
                            displayTGMSLogs = true;
                            return;
                        }
                        if (e.Data.Contains("ENDTGMS"))
                        { 
                            displayTGMSLogs = false;
                            return;
                        }
                    }
                    // Toggle display of TGMS logs
                    if (e.Data.Contains("Failed to create session!") && displayTGMSLogs)
                    {
                        isFetchingEnded = true;
                        timeoutTimer.Stop();
                        batchProcess.Kill();
                        StatusLabel.Invoke((MethodInvoker)(() =>
                            StatusLabel.Text = $"Status: Communication error, contact support."
                        ));
                        if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                        {
                            MessageBox.Show("אין חיבור לרשת.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("אין אפשרות להתחבר לשרת, יש ליצור קשר.", "תקלת תקשורת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (!isFetchingEnded && displayTGMSLogs)
                    { 
                        StatusLabel.Invoke((MethodInvoker)(() =>
                            StatusLabel.Text = $"Status: {e.Data}"
                        ));
                    }


                    // Display logs matching "LOG:"
                    if (!isFetchingEnded && e.Data.Contains("LOG:"))
                    {
                        StatusLabel.Invoke((MethodInvoker)(() =>
                            StatusLabel.Text = $"Status: {e.Data.Remove(0, 4).Trim()}"
                        ));
                    }

                    // Step 4: Check if the operation has ended
                    if (!isFetchingEnded && e.Data.Contains("Fetching ended"))
                    {
                        LogMessage($"Log ended: {DateTime.Now}", true);
                        isFetchingEnded = true;
                        timeoutTimer.Stop();
                        batchProcess.Kill();
                    }
                    LogMessage(e.Data, true);
                }
            };

            // Handle error lines (StandardError)
            batchProcess.ErrorDataReceived += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    StatusLabel.Invoke((MethodInvoker)(() =>
                        StatusLabel.Text = $"ERROR: {e.Data.Trim()}"
                    ));
                }
            };

            try
            {
                batchProcess.Start();
                batchProcess.BeginOutputReadLine();  // Start reading output
                batchProcess.BeginErrorReadLine();   // Start reading errors
                timeoutTimer.Start();                // Start the timeout timer
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to run go.bat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                batchProcess.Kill();
            }

        }
        void ChangeButtonsState(bool enabled)
        {
            ReFetch_Data.Enabled = enabled;
            EAccount.Enabled = enabled;
            ECurrency.Enabled = enabled;
            OpenSettingsButton.Enabled = enabled;
            OpenSettings.Enabled = enabled;
            isFetching = !enabled;
        }
        void LogMessage(string message, bool cleanLog = true)
        {
            try
            {
                // Append the message to the fetchLog.txt file
                using (StreamWriter writer = new StreamWriter(logFilePath, cleanLog))
                {
                    writer.WriteLine($"{message}");
                }
            }
            catch (Exception ex)
            {
                // Handle logging errors (optional)
                MessageBox.Show($"Failed to log message: {ex.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ShowTimeoutError()
        {
            DialogResult result = MessageBox.Show("התהליך נתקע, יש ליצור קשר עם התמיכה.","Timeout Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        void ReadNews()
        { 
            NewsObject newsObject = NewsPuller.PullLatestNews();
            //If there is data, show it.
            if(newsObject != null && newsObject.isimportant)
            {
                NewsContainer.Visible = true;
                NewsText.Text = newsObject.content;
            }
        }

        private void OpenAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void LastFetchLog_Click(object sender, EventArgs e)
        {
            try
            {
                Process appProcess = new Process();
                appProcess.StartInfo.FileName = Path.Combine(Application.StartupPath, "fetchLog.txt");
                appProcess.Start();
            }
            catch (Exception)
            {
                MessageBox.Show(".לא קיים לוג");
            }
        }

        private void ECurrency_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RegistryVariables.DatabaseDir))
                Helpers.RunExternalApp(Path.Combine(Application.StartupPath, "ECurrency.exe"));
            else
                MessageBox.Show("בסיס הנתונים לא הוגדר");
        }
        private void EAccount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RegistryVariables.DatabaseDir))
                Helpers.RunExternalApp(Path.Combine(Application.StartupPath, "EAccount.exe"));
            else
                MessageBox.Show("בסיס הנתונים לא הוגדר");
        }

        private void MenuStripSupport_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            support.ShowDialog();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFetching)
            {
                LogMessage("------------------------------------");
                LogMessage("USER TERMINATED THE FETCHING PROCESS");
                LogMessage("------------------------------------");
            }
        }
    }
}
