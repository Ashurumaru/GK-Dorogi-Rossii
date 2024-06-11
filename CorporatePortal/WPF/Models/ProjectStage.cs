using System;
using System.Collections.Generic;

namespace CorporatePortal.WPF.Models
{
    public partial class ProjectStage
    {
        public int IdStageProject { get; set; }

        public int? IdProject { get; set; }

        public string NameState { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? IdStatusStage { get; set; }

        public string DescriptionStage { get; set; }

        public virtual Project IdProjectNavigation { get; set; }

        public virtual ProjectStateStatus IdStatusStageNavigation { get; set; }
    }
}