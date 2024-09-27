namespace GoldnetWrapper.Core.UserControls
{
    partial class NewsBlock
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
            this.title = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.Label();
            this.datePublished = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.title.Size = new System.Drawing.Size(361, 25);
            this.title.TabIndex = 0;
            this.title.Text = "כותרת";
            // 
            // content
            // 
            this.content.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.content.ForeColor = System.Drawing.SystemColors.MenuText;
            this.content.Location = new System.Drawing.Point(0, 42);
            this.content.Name = "content";
            this.content.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.content.Size = new System.Drawing.Size(361, 47);
            this.content.TabIndex = 1;
            this.content.Text = "תוכן";
            this.content.UseMnemonic = false;
            // 
            // datePublished
            // 
            this.datePublished.Dock = System.Windows.Forms.DockStyle.Top;
            this.datePublished.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePublished.Location = new System.Drawing.Point(0, 25);
            this.datePublished.Name = "datePublished";
            this.datePublished.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePublished.Size = new System.Drawing.Size(361, 20);
            this.datePublished.TabIndex = 2;
            this.datePublished.Text = "פורסם בתאריך: 1/1/1 12:00";
            // 
            // NewsBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.content);
            this.Controls.Add(this.datePublished);
            this.Controls.Add(this.title);
            this.Name = "NewsBlock";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(361, 89);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label content;
        private System.Windows.Forms.Label datePublished;
    }
}
