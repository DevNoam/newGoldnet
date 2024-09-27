using GoldnetWrapper.Core;
using GoldnetWrapper.Core.Properties;
using GoldnetWrapper.Core.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldnetWrapper
{
    public partial class Support : Form
    {
        string ediBox = "ZAHAVID";
        public Support()
        {
            InitializeComponent();

            //Get ediBox;
            EDIId.Text = $"מזהה תיבה: {ediBox}";
            Phone.Text = $"📞: {ReadOnlyVariables.supportPhone}";
            Mail.Text = $"📧: {ReadOnlyVariables.supportEmail}";

            NewsObject[] news = NewsPuller.PullAllNews();
            if (news.Length > 0)
            {
                newsContainer.Controls.Clear();
                foreach (var n in news)
                {
                    //newsBlock.Init(n);
                    NewsBlock newsObject = new NewsBlock();
                    newsObject.Init(n);
                    newsContainer.Controls.Add(newsObject);
                }
            }
        }

        private void SelfAssistPortal_Click(object sender, EventArgs e) => Helpers.OpenURL(ReadOnlyVariables.selfServicePortal);

        private void Mail_Click(object sender, EventArgs e) => Clipboard.SetText(ReadOnlyVariables.supportEmail);

        private void Phone_Click(object sender, EventArgs e) => Clipboard.SetText(ReadOnlyVariables.supportPhone);

        private void EDIId_Click(object sender, EventArgs e) => Clipboard.SetText(ediBox);
    }
}
