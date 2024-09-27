using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldnetWrapper.Core.Properties
{
    public class NewsObject
    {
        public string title { get; set; }
        public string content { get; set; }
        public string datepublished { get; set; }
        public bool isimportant { get; set; }
    }
    public class NewsResponse
    {
        public NewsObject[] news { get; set; }
    }
}
