﻿using System;
using System.Collections.Generic;

namespace CorporatePortal.WPF.Models
{
    public partial class ProjectStateStatus
    {
        public int IdStatusStage { get; set; }

        public string NameStatus { get; set; }

        public virtual ICollection<ProjectStage> ProjectStages { get; set; } = new List<ProjectStage>();
    }
}