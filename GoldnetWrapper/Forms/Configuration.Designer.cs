namespace GoldnetWrapper.Forms
{
    partial class Configuration
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            this.downloadThreadsLabel = new System.Windows.Forms.Label();
            this.tgmsAppProperties = new System.Windows.Forms.Label();
            this.openExportWizard = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.כללי = new System.Windows.Forms.TabPage();
            this.AutoFetchData = new System.Windows.Forms.CheckBox();
            this.tgmsPathSelect = new System.Windows.Forms.Button();
            this.tgmsPath = new System.Windows.Forms.TextBox();
            this.downloadThreadsTGMS = new System.Windows.Forms.NumericUpDown();
            this.updateSSH = new System.Windows.Forms.Button();
            this.EDIBoxID = new System.Windows.Forms.TextBox();
            this.dbPathSelect = new System.Windows.Forms.Button();
            this.dbPath = new System.Windows.Forms.TextBox();
            this.ייצואים = new System.Windows.Forms.TabPage();
            this.backupExportFiles = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.disabledRepsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.enabledRepsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.matahFile = new System.Windows.Forms.TextBox();
            this.selectMatahFile = new System.Windows.Forms.Button();
            this.exportMatah = new System.Windows.Forms.CheckBox();
            this.openRepImportPath = new System.Windows.Forms.Button();
            this.checkBalance = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.כללי.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadThreadsTGMS)).BeginInit();
            this.ייצואים.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Right;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(179, 3);
            label1.Name = "label1";
            label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label1.Size = new System.Drawing.Size(130, 25);
            label1.TabIndex = 0;
            label1.Text = "הגדרות כלליות:";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(186, 0);
            label2.Name = "label2";
            label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label2.Size = new System.Drawing.Size(120, 25);
            label2.TabIndex = 1;
            label2.Text = "הגדרות ייצוא:";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(208, 71);
            label5.Name = "label5";
            label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label5.Size = new System.Drawing.Size(98, 17);
            label5.TabIndex = 4;
            label5.Text = "מזהה תיבת זהב:";
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(230, 28);
            label6.Name = "label6";
            label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label6.Size = new System.Drawing.Size(74, 17);
            label6.TabIndex = 5;
            label6.Text = "בסיס נתונים";
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(216, 139);
            label8.Name = "label8";
            label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label8.Size = new System.Drawing.Size(88, 17);
            label8.TabIndex = 35;
            label8.Text = "תיקיית TGMS";
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(173, 114);
            label7.Name = "label7";
            label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label7.Size = new System.Drawing.Size(133, 25);
            label7.TabIndex = 34;
            label7.Text = "הגדרות תקשורת";
            // 
            // downloadThreadsLabel
            // 
            this.downloadThreadsLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.downloadThreadsLabel.AutoSize = true;
            this.downloadThreadsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadThreadsLabel.Location = new System.Drawing.Point(177, 216);
            this.downloadThreadsLabel.Name = "downloadThreadsLabel";
            this.downloadThreadsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.downloadThreadsLabel.Size = new System.Drawing.Size(123, 17);
            this.downloadThreadsLabel.TabIndex = 33;
            this.downloadThreadsLabel.Text = "מהירות הורדת נתונים";
            // 
            // tgmsAppProperties
            // 
            this.tgmsAppProperties.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tgmsAppProperties.AutoSize = true;
            this.tgmsAppProperties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tgmsAppProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgmsAppProperties.Location = new System.Drawing.Point(157, 262);
            this.tgmsAppProperties.Name = "tgmsAppProperties";
            this.tgmsAppProperties.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tgmsAppProperties.Size = new System.Drawing.Size(147, 17);
            this.tgmsAppProperties.TabIndex = 24;
            this.tgmsAppProperties.Text = "הגדרות TGMS מתקדמות";
            this.tgmsAppProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tgmsAppProperties.Click += new System.EventHandler(this.tgmsAppProperties_Click);
            // 
            // openExportWizard
            // 
            this.openExportWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openExportWizard.AutoSize = true;
            this.openExportWizard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openExportWizard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openExportWizard.Location = new System.Drawing.Point(3, 421);
            this.openExportWizard.Name = "openExportWizard";
            this.openExportWizard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openExportWizard.Size = new System.Drawing.Size(92, 17);
            this.openExportWizard.TabIndex = 26;
            this.openExportWizard.Text = "Export wizard";
            this.openExportWizard.Click += new System.EventHandler(this.openExportWizard_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.כללי);
            this.tabControl1.Controls.Add(this.ייצואים);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 467);
            this.tabControl1.TabIndex = 34;
            // 
            // כללי
            // 
            this.כללי.Controls.Add(this.AutoFetchData);
            this.כללי.Controls.Add(this.tgmsPathSelect);
            this.כללי.Controls.Add(this.tgmsPath);
            this.כללי.Controls.Add(label8);
            this.כללי.Controls.Add(label7);
            this.כללי.Controls.Add(this.downloadThreadsLabel);
            this.כללי.Controls.Add(this.downloadThreadsTGMS);
            this.כללי.Controls.Add(this.updateSSH);
            this.כללי.Controls.Add(this.EDIBoxID);
            this.כללי.Controls.Add(this.dbPathSelect);
            this.כללי.Controls.Add(this.dbPath);
            this.כללי.Controls.Add(label1);
            this.כללי.Controls.Add(label5);
            this.כללי.Controls.Add(label6);
            this.כללי.Controls.Add(this.openExportWizard);
            this.כללי.Controls.Add(this.tgmsAppProperties);
            this.כללי.Location = new System.Drawing.Point(4, 22);
            this.כללי.Name = "כללי";
            this.כללי.Padding = new System.Windows.Forms.Padding(3);
            this.כללי.Size = new System.Drawing.Size(312, 441);
            this.כללי.TabIndex = 0;
            this.כללי.Text = "כללי";
            this.כללי.UseVisualStyleBackColor = true;
            // 
            // AutoFetchData
            // 
            this.AutoFetchData.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AutoFetchData.AutoSize = true;
            this.AutoFetchData.Location = new System.Drawing.Point(141, 242);
            this.AutoFetchData.Name = "AutoFetchData";
            this.AutoFetchData.Size = new System.Drawing.Size(160, 17);
            this.AutoFetchData.TabIndex = 48;
            this.AutoFetchData.Text = "משיכת נתונים אוטומאטית";
            this.AutoFetchData.UseVisualStyleBackColor = true;
            // 
            // tgmsPathSelect
            // 
            this.tgmsPathSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tgmsPathSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgmsPathSelect.Location = new System.Drawing.Point(281, 159);
            this.tgmsPathSelect.Name = "tgmsPathSelect";
            this.tgmsPathSelect.Size = new System.Drawing.Size(23, 20);
            this.tgmsPathSelect.TabIndex = 37;
            this.tgmsPathSelect.Text = "...";
            this.tgmsPathSelect.UseVisualStyleBackColor = true;
            this.tgmsPathSelect.Click += new System.EventHandler(this.tgmsPathSelect_Click);
            // 
            // tgmsPath
            // 
            this.tgmsPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tgmsPath.Location = new System.Drawing.Point(100, 159);
            this.tgmsPath.Name = "tgmsPath";
            this.tgmsPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tgmsPath.Size = new System.Drawing.Size(178, 20);
            this.tgmsPath.TabIndex = 36;
            this.tgmsPath.Text = "C:\\Goldnet\\TGMS";
            this.tgmsPath.Leave += new System.EventHandler(this.tgmsPath_Leave);
            // 
            // downloadThreadsTGMS
            // 
            this.downloadThreadsTGMS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.downloadThreadsTGMS.Location = new System.Drawing.Point(118, 216);
            this.downloadThreadsTGMS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.downloadThreadsTGMS.Name = "downloadThreadsTGMS";
            this.downloadThreadsTGMS.Size = new System.Drawing.Size(53, 20);
            this.downloadThreadsTGMS.TabIndex = 32;
            this.downloadThreadsTGMS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // updateSSH
            // 
            this.updateSSH.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.updateSSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateSSH.Location = new System.Drawing.Point(124, 185);
            this.updateSSH.Name = "updateSSH";
            this.updateSSH.Size = new System.Drawing.Size(180, 28);
            this.updateSSH.TabIndex = 31;
            this.updateSSH.Text = "תיקיית תקשורת (TGMS)";
            this.updateSSH.UseVisualStyleBackColor = true;
            this.updateSSH.Click += new System.EventHandler(this.OpentgmsFolder);
            // 
            // EDIBoxID
            // 
            this.EDIBoxID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EDIBoxID.Location = new System.Drawing.Point(126, 91);
            this.EDIBoxID.Name = "EDIBoxID";
            this.EDIBoxID.ReadOnly = true;
            this.EDIBoxID.Size = new System.Drawing.Size(178, 20);
            this.EDIBoxID.TabIndex = 30;
            this.EDIBoxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dbPathSelect
            // 
            this.dbPathSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dbPathSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbPathSelect.Location = new System.Drawing.Point(281, 48);
            this.dbPathSelect.Name = "dbPathSelect";
            this.dbPathSelect.Size = new System.Drawing.Size(23, 20);
            this.dbPathSelect.TabIndex = 29;
            this.dbPathSelect.Text = "...";
            this.dbPathSelect.UseVisualStyleBackColor = true;
            this.dbPathSelect.Click += new System.EventHandler(this.dbPathSelect_Click);
            // 
            // dbPath
            // 
            this.dbPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dbPath.Location = new System.Drawing.Point(100, 48);
            this.dbPath.Name = "dbPath";
            this.dbPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dbPath.Size = new System.Drawing.Size(178, 20);
            this.dbPath.TabIndex = 28;
            this.dbPath.Text = "C:\\Goldnet\\Data";
            // 
            // ייצואים
            // 
            this.ייצואים.Controls.Add(this.backupExportFiles);
            this.ייצואים.Controls.Add(this.label9);
            this.ייצואים.Controls.Add(this.disabledRepsPanel);
            this.ייצואים.Controls.Add(this.label4);
            this.ייצואים.Controls.Add(this.enabledRepsPanel);
            this.ייצואים.Controls.Add(this.matahFile);
            this.ייצואים.Controls.Add(this.selectMatahFile);
            this.ייצואים.Controls.Add(this.exportMatah);
            this.ייצואים.Controls.Add(this.openRepImportPath);
            this.ייצואים.Controls.Add(label2);
            this.ייצואים.Controls.Add(this.checkBalance);
            this.ייצואים.Location = new System.Drawing.Point(4, 22);
            this.ייצואים.Name = "ייצואים";
            this.ייצואים.Padding = new System.Windows.Forms.Padding(3);
            this.ייצואים.Size = new System.Drawing.Size(312, 441);
            this.ייצואים.TabIndex = 1;
            this.ייצואים.Text = "ייצואים";
            this.ייצואים.UseVisualStyleBackColor = true;
            // 
            // backupExportFiles
            // 
            this.backupExportFiles.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.backupExportFiles.AutoSize = true;
            this.backupExportFiles.Location = new System.Drawing.Point(185, 332);
            this.backupExportFiles.Name = "backupExportFiles";
            this.backupExportFiles.Size = new System.Drawing.Size(116, 17);
            this.backupExportFiles.TabIndex = 47;
            this.backupExportFiles.Text = "גיבוי קבצי ייצוא";
            this.backupExportFiles.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "ייצואים זמינים";
            // 
            // disabledRepsPanel
            // 
            this.disabledRepsPanel.AutoScroll = true;
            this.disabledRepsPanel.Location = new System.Drawing.Point(-3, 164);
            this.disabledRepsPanel.Name = "disabledRepsPanel";
            this.disabledRepsPanel.Size = new System.Drawing.Size(309, 108);
            this.disabledRepsPanel.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "ייצואים פעילים";
            // 
            // enabledRepsPanel
            // 
            this.enabledRepsPanel.AutoScroll = true;
            this.enabledRepsPanel.Location = new System.Drawing.Point(-3, 39);
            this.enabledRepsPanel.Name = "enabledRepsPanel";
            this.enabledRepsPanel.Size = new System.Drawing.Size(309, 108);
            this.enabledRepsPanel.TabIndex = 43;
            // 
            // matahFile
            // 
            this.matahFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.matahFile.Location = new System.Drawing.Point(97, 381);
            this.matahFile.Name = "matahFile";
            this.matahFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.matahFile.Size = new System.Drawing.Size(178, 20);
            this.matahFile.TabIndex = 39;
            this.matahFile.Text = "C:\\Goldnet\\raw.dat";
            // 
            // selectMatahFile
            // 
            this.selectMatahFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.selectMatahFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectMatahFile.Location = new System.Drawing.Point(278, 381);
            this.selectMatahFile.Name = "selectMatahFile";
            this.selectMatahFile.Size = new System.Drawing.Size(23, 20);
            this.selectMatahFile.TabIndex = 40;
            this.selectMatahFile.Text = "...";
            this.selectMatahFile.UseVisualStyleBackColor = true;
            this.selectMatahFile.Click += new System.EventHandler(this.selectMatahFile_Click);
            // 
            // exportMatah
            // 
            this.exportMatah.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.exportMatah.AutoSize = true;
            this.exportMatah.Location = new System.Drawing.Point(158, 358);
            this.exportMatah.Name = "exportMatah";
            this.exportMatah.Size = new System.Drawing.Size(143, 17);
            this.exportMatah.TabIndex = 21;
            this.exportMatah.Text = "ייצוא קובץ מטח גולמי";
            this.exportMatah.UseVisualStyleBackColor = true;
            this.exportMatah.CheckedChanged += new System.EventHandler(this.exportMatah_CheckedChanged);
            // 
            // openRepImportPath
            // 
            this.openRepImportPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.openRepImportPath.Location = new System.Drawing.Point(149, 279);
            this.openRepImportPath.Name = "openRepImportPath";
            this.openRepImportPath.Size = new System.Drawing.Size(152, 23);
            this.openRepImportPath.TabIndex = 20;
            this.openRepImportPath.Text = "פתח תיקיית ייבוא REP";
            this.openRepImportPath.UseVisualStyleBackColor = true;
            this.openRepImportPath.Click += new System.EventHandler(this.openRepImportPath_Click);
            // 
            // checkBalance
            // 
            this.checkBalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBalance.AutoSize = true;
            this.checkBalance.Location = new System.Drawing.Point(149, 309);
            this.checkBalance.Name = "checkBalance";
            this.checkBalance.Size = new System.Drawing.Size(152, 17);
            this.checkBalance.TabIndex = 19;
            this.checkBalance.Text = "בדיקת יתרות לפני ייצוא";
            this.checkBalance.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(205, 429);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(106, 29);
            this.SaveButton.TabIndex = 38;
            this.SaveButton.Text = "שמירה";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 467);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "קונפיגורציה";
            this.tabControl1.ResumeLayout(false);
            this.כללי.ResumeLayout(false);
            this.כללי.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadThreadsTGMS)).EndInit();
            this.ייצואים.ResumeLayout(false);
            this.ייצואים.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tgmsAppProperties;
        private System.Windows.Forms.Label openExportWizard;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage כללי;
        private System.Windows.Forms.TabPage ייצואים;
        private System.Windows.Forms.CheckBox checkBalance;
        private System.Windows.Forms.Button updateSSH;
        private System.Windows.Forms.TextBox EDIBoxID;
        private System.Windows.Forms.Button dbPathSelect;
        private System.Windows.Forms.TextBox dbPath;
        private System.Windows.Forms.Button openRepImportPath;
        private System.Windows.Forms.NumericUpDown downloadThreadsTGMS;
        private System.Windows.Forms.Button tgmsPathSelect;
        private System.Windows.Forms.TextBox tgmsPath;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox exportMatah;
        private System.Windows.Forms.TextBox matahFile;
        private System.Windows.Forms.Button selectMatahFile;
        private System.Windows.Forms.FlowLayoutPanel enabledRepsPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel disabledRepsPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox backupExportFiles;
        private System.Windows.Forms.CheckBox AutoFetchData;
        private System.Windows.Forms.Label downloadThreadsLabel;
    }
}