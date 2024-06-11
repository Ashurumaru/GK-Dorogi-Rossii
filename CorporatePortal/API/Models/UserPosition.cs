﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class UserPosition
{
    public int IdPosition { get; set; }

    public string? NamePosition { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
