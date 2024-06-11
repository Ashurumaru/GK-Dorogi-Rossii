using System;
using System.Collections.Generic;

namespace CorporatePortal.WPF.Models
{
    public partial class UserAccount
    {
        public int IdUserAccount { get; set; }

        public int IdUser { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public int? IdRole { get; set; }

        public virtual UserRole IdRoleNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; } = null;
    }
}
