using GoldnetWrapper.Core.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoldnetWrapper.Core.UserControls
{
    public partial class RepSelector : UserControl
    {
        private bool isEnabled = false;
        private RepData repData;
        public event EventHandler RepStateChanged;

        public RepSelector(RepData data)
        {
            this.repData = data;
            InitializeComponent();
            InitRep();
        }

        public void InitRep()
        {
            isEnabled = Convert.ToBoolean(repData.Enabled);
            using (Graphics g = CreateGraphics())
            {
                SizeF size = g.MeasureString(repData.repName, repName.Font, 495);
                repName.Height = (int)Math.Ceiling(size.Height);
                repName.Text = repData.repName;
            }

            exportPath.Enabled = true;
            repSelectPath.Enabled = true;
            exportPath.Text = $"{repData.OutputFolder}";
            if (isEnabled)
            {
                enableOrDisableRep.Text = "-";
            }
            else
            {
                enableOrDisableRep.Text = "+";
            }

        }

        private void repSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFileDialog = new FolderBrowserDialog();
            saveFileDialog.Description = "Choose export path";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            { 
                repData.OutputFolder = saveFileDialog.SelectedPath;
                exportPath.Text = $"{repData.OutputFolder}";
            }
        }

        private void enableOrDisableRep_Click(object sender, EventArgs e) => HandleEnableDisable();

        public void HandleEnableDisable()
        {
            repData.Enabled = repData.Enabled == 1 ? 0 : 1;
            enableOrDisableRep.Text = repData.Enabled == 1 ? "-" : "+";
            RepStateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void exportPath_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(exportPath.Text) && !Helpers.IsValidPath(exportPath.Text))
            { 
                MessageBox.Show("נתיב לא תקין", "Path invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                repData.OutputFolder = exportPath.Text;
        }
        public RepData GetRepData()
        {
            return repData;
        }
    }
}
