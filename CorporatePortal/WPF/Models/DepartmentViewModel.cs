using CorporatePortal.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    internal class DepartmentViewModel
    {
        public int IdDepartment { get; set; }
        public string NameDepartment { get; set; }
        public ObservableCollection<DepartmentViewModel> SubDepartments { get; set; }
        public ObservableCollection<User> Users { get; set; }

        public DepartmentViewModel(Department department)
        {
            IdDepartment = department.IdDepartrment;
            NameDepartment = department.NameDepartment;
            SubDepartments = new ObservableCollection<DepartmentViewModel>(
                department.InverseIdParentDepartmentNavigation.Select(d => new DepartmentViewModel(d)));
            Users = new ObservableCollection<User>(department.Users);
        }
    }
}
