using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ProjectStage
{
    public int IdStageProject { get; set; }

    public int? IdProject { get; set; }

    public string? NameState { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? IdStatusStage { get; set; }

    public string? DescriptionStage { get; set; }

    public virtual Project? IdProjectNavigation { get; set; }

    public virtual ProjectStateStatus? IdStatusStageNavigation { get; set; }
}
