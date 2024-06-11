using System;
using System.Collections.Generic;

namespace CorporatePortal.WPF.Models
{
    public partial class ProjectStatus
    {
        public int IdStatusProject { get; set; }

        public string NameStatus { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}