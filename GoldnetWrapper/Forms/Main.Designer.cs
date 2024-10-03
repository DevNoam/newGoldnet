namespace GoldnetWrapper
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.קובץToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReFetch_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.לוגמשיכהToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.WelcomeHeader = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.NewsContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NewsText = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.EAccount = new System.Windows.Forms.PictureBox();
            this.ECurrency = new System.Windows.Forms.PictureBox();
            this.GetSupport = new System.Windows.Forms.Button();
            this.OpenSettingsButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.NewsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ECurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.קובץToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(806, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // קובץToolStripMenuItem
            // 
            this.קובץToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.קובץToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReFetch_Data,
            this.OpenSettings,
            this.OpenAbout,
            this.toolStripSeparator2,
            this.ExitApp});
            this.קובץToolStripMenuItem.Name = "קובץToolStripMenuItem";
            this.קובץToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.קובץToolStripMenuItem.Text = "פעולות";
            // 
            // ReFetch_Data
            // 
            this.ReFetch_Data.Name = "ReFetch_Data";
            this.ReFetch_Data.Size = new System.Drawing.Size(146, 22);
            this.ReFetch_Data.Text = "משיכת נתונים";
            this.ReFetch_Data.Click += new System.EventHandler(this.ReFetch_Data_Click);
            // 
            // OpenSettings
            // 
            this.OpenSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.לוגמשיכהToolStripMenuItem});
            this.OpenSettings.Name = "OpenSettings";
            this.OpenSettings.Size = new System.Drawing.Size(146, 22);
            this.OpenSettings.Text = "הגדרות";
            this.OpenSettings.Click += new System.EventHandler(this.OpenSettings_Click);
            // 
            // לוגמשיכהToolStripMenuItem
            // 
            this.לוגמשיכהToolStripMenuItem.Name = "לוגמשיכהToolStripMenuItem";
            this.לוגמשיכהToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.לוגמשיכהToolStripMenuItem.Text = "לוג משיכה";
            this.לוגמשיכהToolStripMenuItem.Click += new System.EventHandler(this.LastFetchLog_Click);
            // 
            // OpenAbout
            // 
            this.OpenAbout.Name = "OpenAbout";
            this.OpenAbout.Size = new System.Drawing.Size(146, 22);
            this.OpenAbout.Text = "אודות";
            this.OpenAbout.Click += new System.EventHandler(this.OpenAbout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // ExitApp
            // 
            this.ExitApp.Name = "ExitApp";
            this.ExitApp.Size = new System.Drawing.Size(146, 22);
            this.ExitApp.Text = "יציאה";
            this.ExitApp.Click += new System.EventHandler(this.ExitApp_Click);
            // 
            // WelcomeHeader
            // 
            this.WelcomeHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WelcomeHeader.BackColor = System.Drawing.Color.Transparent;
            this.WelcomeHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WelcomeHeader.Font = new System.Drawing.Font("Arial", 19F, System.Drawing.FontStyle.Bold);
            this.WelcomeHeader.Location = new System.Drawing.Point(557, 26);
            this.WelcomeHeader.Margin = new System.Windows.Forms.Padding(0);
            this.WelcomeHeader.Name = "WelcomeHeader";
            this.WelcomeHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WelcomeHeader.Size = new System.Drawing.Size(249, 41);
            this.WelcomeHeader.TabIndex = 1;
            this.WelcomeHeader.Text = "בוקר טוב,";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Arial", 9F);
            this.StatusLabel.Location = new System.Drawing.Point(654, 57);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(152, 42);
            this.StatusLabel.TabIndex = 11;
            // 
            // NewsContainer
            // 
            this.NewsContainer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NewsContainer.Controls.Add(this.pictureBox1);
            this.NewsContainer.Controls.Add(this.NewsText);
            this.NewsContainer.ForeColor = System.Drawing.SystemColors.Info;
            this.NewsContainer.Location = new System.Drawing.Point(127, 417);
            this.NewsContainer.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.NewsContainer.Name = "NewsContainer";
            this.NewsContainer.Size = new System.Drawing.Size(528, 51);
            this.NewsContainer.TabIndex = 14;
            this.NewsContainer.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.BackColor = System.Drawing.Color.Firebrick;
            this.pictureBox1.BackgroundImage = global::MultiBill.Properties.Resources.icons8_info_150;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 51);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // NewsText
            // 
            this.NewsText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NewsText.BackColor = System.Drawing.Color.Firebrick;
            this.NewsText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NewsText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewsText.Font = new System.Drawing.Font("Arial", 15F);
            this.NewsText.ForeColor = System.Drawing.Color.White;
            this.NewsText.Location = new System.Drawing.Point(49, 0);
            this.NewsText.Margin = new System.Windows.Forms.Padding(0);
            this.NewsText.Name = "NewsText";
            this.NewsText.Size = new System.Drawing.Size(479, 53);
            this.NewsText.TabIndex = 11;
            this.NewsText.Text = "טקסט תקלה";
            this.NewsText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Logo
            // 
            this.Logo.BackgroundImage = global::MultiBill.Properties.Resources.download;
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logo.Location = new System.Drawing.Point(6, 13);
            this.Logo.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(155, 70);
            this.Logo.TabIndex = 13;
            this.Logo.TabStop = false;
            this.Logo.Click += new System.EventHandler(this.Logo_Click);
            // 
            // EAccount
            // 
            this.EAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.EAccount.BackColor = System.Drawing.Color.Transparent;
            this.EAccount.BackgroundImage = global::MultiBill.Properties.Resources.matah;
            this.EAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EAccount.Location = new System.Drawing.Point(167, 110);
            this.EAccount.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.EAccount.Name = "EAccount";
            this.EAccount.Size = new System.Drawing.Size(213, 278);
            this.EAccount.TabIndex = 3;
            this.EAccount.TabStop = false;
            this.EAccount.Click += new System.EventHandler(this.ECurrency_Click);
            // 
            // ECurrency
            // 
            this.ECurrency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ECurrency.BackColor = System.Drawing.Color.Transparent;
            this.ECurrency.BackgroundImage = global::MultiBill.Properties.Resources.mivzaq;
            this.ECurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ECurrency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ECurrency.Location = new System.Drawing.Point(414, 110);
            this.ECurrency.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.ECurrency.Name = "ECurrency";
            this.ECurrency.Size = new System.Drawing.Size(213, 278);
            this.ECurrency.TabIndex = 2;
            this.ECurrency.TabStop = false;
            this.ECurrency.Click += new System.EventHandler(this.EAccount_Click);
            // 
            // GetSupport
            // 
            this.GetSupport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GetSupport.BackColor = System.Drawing.SystemColors.Control;
            this.GetSupport.BackgroundImage = global::MultiBill.Properties.Resources.icons8_headset_94;
            this.GetSupport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GetSupport.Location = new System.Drawing.Point(0, 398);
            this.GetSupport.Name = "GetSupport";
            this.GetSupport.Size = new System.Drawing.Size(81, 77);
            this.GetSupport.TabIndex = 15;
            this.GetSupport.UseVisualStyleBackColor = false;
            this.GetSupport.Click += new System.EventHandler(this.GetSupport_Click);
            // 
            // OpenSettingsButton
            // 
            this.OpenSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenSettingsButton.BackColor = System.Drawing.SystemColors.Control;
            this.OpenSettingsButton.BackgroundImage = global::MultiBill.Properties.Resources.icons8_settings_250;
            this.OpenSettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OpenSettingsButton.Location = new System.Drawing.Point(725, 398);
            this.OpenSettingsButton.Name = "OpenSettingsButton";
            this.OpenSettingsButton.Size = new System.Drawing.Size(81, 77);
            this.OpenSettingsButton.TabIndex = 16;
            this.OpenSettingsButton.UseVisualStyleBackColor = false;
            this.OpenSettingsButton.Click += new System.EventHandler(this.OpenSettingsButton_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(806, 473);
            this.Controls.Add(this.OpenSettingsButton);
            this.Controls.Add(this.GetSupport);
            this.Controls.Add(this.NewsContainer);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.EAccount);
            this.Controls.Add(this.ECurrency);
            this.Controls.Add(this.WelcomeHeader);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Tag = "Status: Idle..";
            this.Text = "MultiBill Services";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.NewsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ECurrency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem קובץToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenSettings;
        private System.Windows.Forms.ToolStripMenuItem OpenAbout;
        private System.Windows.Forms.ToolStripMenuItem ExitApp;
        private System.Windows.Forms.Label WelcomeHeader;
        private System.Windows.Forms.PictureBox ECurrency;
        private System.Windows.Forms.PictureBox EAccount;
        private System.Windows.Forms.ToolStripMenuItem ReFetch_Data;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel NewsContainer;
        private System.Windows.Forms.Label NewsText;
        private System.Windows.Forms.Button GetSupport;
        private System.Windows.Forms.Button OpenSettingsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem לוגמשיכהToolStripMenuItem;
    }
}

