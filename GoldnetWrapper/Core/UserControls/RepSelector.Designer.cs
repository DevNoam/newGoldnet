namespace GoldnetWrapper.Core.UserControls
{
    partial class RepSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.repName = new System.Windows.Forms.Label();
            this.enableOrDisableRep = new System.Windows.Forms.Button();
            this.exportPath = new System.Windows.Forms.TextBox();
            this.repSelectPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // repName
            // 
            this.repName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.repName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repName.Location = new System.Drawing.Point(22, 7);
            this.repName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.repName.Name = "repName";
            this.repName.Size = new System.Drawing.Size(86, 31);
            this.repName.TabIndex = 0;
            this.repName.Text = "REPNAME";
            // 
            // enableOrDisableRep
            // 
            this.enableOrDisableRep.Dock = System.Windows.Forms.DockStyle.Left;
            this.enableOrDisableRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableOrDisableRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableOrDisableRep.Location = new System.Drawing.Point(0, 0);
            this.enableOrDisableRep.Margin = new System.Windows.Forms.Padding(4);
            this.enableOrDisableRep.Name = "enableOrDisableRep";
            this.enableOrDisableRep.Size = new System.Drawing.Size(25, 38);
            this.enableOrDisableRep.TabIndex = 1;
            this.enableOrDisableRep.Text = "-";
            this.enableOrDisableRep.UseVisualStyleBackColor = true;
            this.enableOrDisableRep.Click += new System.EventHandler(this.enableOrDisableRep_Click);
            // 
            // exportPath
            // 
            this.exportPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportPath.Location = new System.Drawing.Point(104, 5);
            this.exportPath.Margin = new System.Windows.Forms.Padding(4);
            this.exportPath.Name = "exportPath";
            this.exportPath.Size = new System.Drawing.Size(227, 30);
            this.exportPath.TabIndex = 2;
            this.exportPath.Leave += new System.EventHandler(this.exportPath_Leave);
            // 
            // repSelectPath
            // 
            this.repSelectPath.Dock = System.Windows.Forms.DockStyle.Right;
            this.repSelectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.repSelectPath.Font = new System.Drawing.Font("MS Reference Specialty", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repSelectPath.Location = new System.Drawing.Point(339, 0);
            this.repSelectPath.Margin = new System.Windows.Forms.Padding(4);
            this.repSelectPath.Name = "repSelectPath";
            this.repSelectPath.Size = new System.Drawing.Size(35, 38);
            this.repSelectPath.TabIndex = 3;
            this.repSelectPath.Text = "...";
            this.repSelectPath.UseVisualStyleBackColor = true;
            this.repSelectPath.Click += new System.EventHandler(this.repSelectPath_Click);
            // 
            // RepSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.repSelectPath);
            this.Controls.Add(this.exportPath);
            this.Controls.Add(this.enableOrDisableRep);
            this.Controls.Add(this.repName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RepSelector";
            this.Size = new System.Drawing.Size(374, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label repName;
        private System.Windows.Forms.Button enableOrDisableRep;
        private System.Windows.Forms.TextBox exportPath;
        private System.Windows.Forms.Button repSelectPath;
    }
}
