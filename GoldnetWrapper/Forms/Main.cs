using GoldnetWrapper.Core;
using GoldnetWrapper.Core.Properties;
using GoldnetWrapper.Forms;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace GoldnetWrapper
{
    public partial class Main : Form
    {
        public static Label StatusLabelVar;
        public Main()
        {
            InitializeComponent();
            StatusLabelVar = this.StatusLabel;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayWelcomeHeader();

            ReadNews();
            //CHECK REGEDIT IF FETCH ON START ENABLED
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

        private void Logo_Click(object sender, EventArgs e)
        {
            Helpers.OpenURL(ReadOnlyVariables.bezeqIntWebsite);
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            Helpers.CloseApplication();
        }

        private void EAccount_Click(object sender, EventArgs e)
        {
            //Run EAccount.exe from current directory
            Helpers.RunExternalApp(Path.Combine(Application.StartupPath, "EAccount.exe"));
        }

        private void ECurrency_Click(object sender, EventArgs e)
        {
            //Run ECurrency.exe from current directory
            Helpers.RunExternalApp(Path.Combine(Application.StartupPath, "ECurrency.exe"));
        }

        private void GetSupport_Click(object sender, EventArgs e)
        {
            //replace form
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
            ChangeButtonsState(false);


            // Step 1: Start the batch file process
            Process batchProcess = new Process();
            batchProcess.StartInfo.FileName = Path.Combine(Application.StartupPath, "go.bat");
            batchProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            batchProcess.StartInfo.CreateNoWindow = true;
            batchProcess.StartInfo.UseShellExecute = false;
            batchProcess.StartInfo.RedirectStandardOutput = true;
            batchProcess.StartInfo.RedirectStandardError = true;


            bool isFetchingEnded = false;
            bool displayTGMSLogs = false;
            System.Timers.Timer timeoutTimer;
            int timeoutInterval = 5000;


            // Timer to detect inactivity
            timeoutTimer = new System.Timers.Timer(timeoutInterval);
            timeoutTimer.Elapsed += (sender, e) =>
            {
                if (!isFetchingEnded)
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

                    // Toggle display of TGMS logs
                    if (displayTGMSLogs)
                    {
                        if (e.Data.Contains("Failed to create session!"))
                        {
                            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                            { 
                                MessageBox.Show("אין חיבור לרשת.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }else if (!CheckInternetConnection("1.1.1.1", 80))  // Replace with your target IP and port
                            {
                                MessageBox.Show("אין גישה לשרת.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            { 
                                MessageBox.Show("אין אפשרות להתחבר לשרת, יש ליצור קשר.", "תקלת תקשורת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            //OPEN SUPPORT PAGE
                        }
                        StatusLabel.Invoke((MethodInvoker)(() =>
                            StatusLabel.Text = $"Status: {e.Data}"
                        ));
                    }

                    if (e.Data.Contains("TGMS"))
                    {
                        if (e.Data == "STARTTGMS")
                            displayTGMSLogs = true;
                        if (e.Data == "ENDTGMS")
                            displayTGMSLogs = false;
                    }

                    // Display logs matching "LOG:"
                    if (e.Data.Contains("LOG:"))
                    {
                        StatusLabel.Invoke((MethodInvoker)(() =>
                            StatusLabel.Text = $"Status: {e.Data.Remove(0, 4).Trim()}"
                        ));
                    }

                    // Step 4: Check if the operation has ended
                    if (e.Data.Contains("Fetching ended"))
                    {
                        isFetchingEnded = true;
                        timeoutTimer.Stop();
                    }
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
            }

            //ENABLE BUTTONS;
            ChangeButtonsState(true);


            void ChangeButtonsState(bool enabled)
            {
                ReFetch_Data.Enabled = enabled;
                EAccount.Enabled = enabled;
                ECurrency.Enabled = enabled;
                OpenSettingsButton.Enabled = enabled;
                OpenSettings.Enabled = enabled;
            }
        }
        private static bool CheckInternetConnection(string host, int port)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(host, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));
                    return success;
                }
            }
            catch
            {
                return false;
            }
        }
        private static void ShowTimeoutError()
        {
            DialogResult result = MessageBox.Show(
                "Operation timed out. What would you like to do?",
                "Timeout Error",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

            switch (result)
            {
                case DialogResult.Yes:   // Show logs
                                         // Implement logic to show logs
                    MessageBox.Show("Displaying log");
                    break;
                case DialogResult.No:    // Contact support
                                         // Implement contact support logic
                    MessageBox.Show("Contact support.");
                    break;
                case DialogResult.Cancel:  // OK button
                                           // Implement logic for OK
                    break;
            }
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

        private void OpenLatestLogFile(object sender, EventArgs e)
        {
            Helpers.RunExternalApp(Path.Combine(Application.StartupPath, "goLog.txt"));
        }
    }
}
