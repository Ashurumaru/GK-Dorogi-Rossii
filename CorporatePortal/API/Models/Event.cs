using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Event
{
    public int IdEvent { get; set; }

    public string? NameEvent { get; set; }

    public int? IdTypeEvent { get; set; }

    public int? IdStatusEvent { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? DescriptionEvent { get; set; }

    public int? IdInitiator { get; set; }

    public virtual User? IdInitiatorNavigation { get; set; }

    public virtual EventStatus? IdStatusEventNavigation { get; set; }

    public virtual EventType? IdTypeEventNavigation { get; set; }

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
