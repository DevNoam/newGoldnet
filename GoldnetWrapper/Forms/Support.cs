using GoldnetWrapper.Core;
using GoldnetWrapper.Core.Properties;
using GoldnetWrapper.Core.UserControls;
using System;
using System.Windows.Forms;

namespace GoldnetWrapper
{
    public partial class Support : Form
    {
        public Support()
        {
            InitializeComponent();

            //Get ediBox;
            EDIId.Text = $"מזהה תיבה: {RegistryVariables.EDIUsername}";
            Phone.Text = $"📞: {ReadOnlyVariables.supportPhone}";
            Mail.Text = $"📧: {ReadOnlyVariables.supportEmail}";

            NewsObject[] news = NewsPuller.PullAllNews();
            try
            {
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
            catch (Exception ex)
            { Console.WriteLine("Failed to load news: " + ex.Message); }
        }

        private void SelfAssistPortal_Click(object sender, EventArgs e) => Helpers.OpenURL(ReadOnlyVariables.selfServicePortal);

        private void Mail_Click(object sender, EventArgs e) => Clipboard.SetText(ReadOnlyVariables.supportEmail);

        private void Phone_Click(object sender, EventArgs e) => Clipboard.SetText(ReadOnlyVariables.supportPhone);

        private void EDIId_Click(object sender, EventArgs e) => Clipboard.SetText(RegistryVariables.EDIUsername);
    }
}
