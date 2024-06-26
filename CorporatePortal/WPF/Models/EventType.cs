﻿using System;
using System.Collections.Generic;

namespace CorporatePortal.WPF.Models
{
    public partial class EventType
    {
        public int IdTypeEvent { get; set; }

        public string NameType { get; set; }

        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}