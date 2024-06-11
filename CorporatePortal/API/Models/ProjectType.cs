using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ProjectType
{
    public int IdTypeProject { get; set; }

    public string? NameType { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
