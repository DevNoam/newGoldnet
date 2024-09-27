using GoldnetWrapper.Core.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldnetWrapper.Core.UserControls
{
    public partial class NewsBlock : UserControl
    {
        public NewsBlock()
        {
            InitializeComponent();
        }
        public void Init(NewsObject newsObject)
        {
            title.Text = newsObject.title;
            datePublished.Text = newsObject.datepublished;
            content.Text = newsObject.content;
        }
    }
}
