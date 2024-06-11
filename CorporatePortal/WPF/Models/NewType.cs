using System;
using System.Collections.Generic;

namespace CorporatePortal.WPF.Models
{
    public partial class NewType
    {
        public int IdTypeNew { get; set; }

        public string NameType { get; set; }

        public virtual ICollection<News> News { get; set; } = new List<News>();
    }
}