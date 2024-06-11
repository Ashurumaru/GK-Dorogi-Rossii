using System;
using System.Collections.Generic;

namespace CorporatePortal.WPF.Models
{
    public partial class Department
    {
        public int IdDepartrment { get; set; }

        public string NameDepartment { get; set; }

        public int? IdDirectorDepartment { get; set; }

        public int? IdSupportDirectorDepartment { get; set; }

        public int? IdParentDepartment { get; set; }

        public virtual Department IdParentDepartmentNavigation { get; set; }

        public virtual ICollection<Department> InverseIdParentDepartmentNavigation { get; set; } = new List<Department>();

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}