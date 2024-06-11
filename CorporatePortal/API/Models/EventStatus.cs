using System;
using System.Collections.Generic;

namespace API.Models;

public partial class EventStatus
{
    public int IdStatusEvent { get; set; }

    public string? NameStatus { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
