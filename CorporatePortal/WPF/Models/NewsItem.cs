using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    public class NewsItem
    {
        public int IdNew { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int? IdTypeNew { get; set; }
        public int? IdCreator { get; set; }
    }
}
