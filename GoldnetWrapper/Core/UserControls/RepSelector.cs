using GoldnetWrapper.Core.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GoldnetWrapper.Core.UserControls
{
    public partial class RepSelector : UserControl
    {
        public bool isEnabled = false;
        RepData repData;

        public RepSelector()
        {
            InitializeComponent();
        }

        public void InitRep(RepData repData)
        {
            this.repData = repData;
            isEnabled = repData.isEnabled;
            using (Graphics g = CreateGraphics())
            {
                SizeF size = g.MeasureString(repData.repName, repName.Font, 495);
                repName.Height = (int)Math.Ceiling(size.Height);
                repName.Text = repData.repName;
            }

            if (isEnabled)
            {
                enableOrDisableRep.Text = "-";
                exportPath.Enabled = true;
                repSelectPath.Enabled = true;
                exportPath.Text = $"{repData.repExportPath}\\{repData.repExportName}";
            }
            else
            {
                enableOrDisableRep.Text = "+";
            }

        }

        private void repSelectPath_Click(object sender, EventArgs e)
        {
            //Open file dialog
        }

        private void repName_Click(object sender, EventArgs e)
        {

        }

        private void exportPath_TextChanged(object sender, EventArgs e)
        {
            //Validate that the path contains a valid file name
        }

        private void enableOrDisableRep_Click(object sender, EventArgs e)
        {
            if(isEnabled)
            {
                DisableRep();
            }
            else
            {
                EnableRep();
            }
        }

        void EnableRep()
        {
            //Move rep from RepBank
            // Add rep to GNEXIMPORT
            // ADD REP TO REGISTRY
        }
        void DisableRep()
        {
            //Move rep to RepBank
            // Delete rep from GNEXIMPORT
            // DELETE REP FROM REGISTRY
        }
    }
}
