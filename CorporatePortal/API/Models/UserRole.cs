﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class UserRole
{
    public int IdRole { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
