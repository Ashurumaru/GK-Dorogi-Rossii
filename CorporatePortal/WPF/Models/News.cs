using System;
using System.Collections.Generic;

namespace CorporatePortal.WPF.Models
{
    public partial class News
    {
        public int IdNew { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public int? IdTypeNew { get; set; }

        public int? IdCreator { get; set; }

        public virtual User IdCreatorNavigation { get; set; }

        public virtual NewType IdTypeNewNavigation { get; set; }
    }
}