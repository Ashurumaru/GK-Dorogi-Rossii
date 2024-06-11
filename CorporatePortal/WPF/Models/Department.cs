using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePortal.WPF.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Department
    {
        public int idDepartment { get; set; }
        public string nameDepartment { get; set; }
        public int? idDirectorDepartment { get; set; }
        public int? idSupportDirectorDepartment { get; set; }
        public int? idParentDepartment { get; set; }
    }
}
