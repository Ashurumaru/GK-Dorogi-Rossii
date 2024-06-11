using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Project
{
    public int IdProject { get; set; }

    public string? NameProject { get; set; }

    public string? DescriptoinProject { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? IdDepartment { get; set; }

    public int? IdStatusProject { get; set; }

    public int? IdTypeProject { get; set; }

    public virtual Department? IdDepartmentNavigation { get; set; }

    public virtual ProjectStatus? IdStatusProjectNavigation { get; set; }

    public virtual ProjectType? IdTypeProjectNavigation { get; set; }

    public virtual ICollection<ProjectStage> ProjectStages { get; set; } = new List<ProjectStage>();

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
