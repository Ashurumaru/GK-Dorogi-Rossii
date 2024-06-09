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
        public int ПодразделениеID { get; set; }
        public string НазваниеПодразделения { get; set; }
        public int? РуководительПодразделения { get; set; }
        public int? ПомощникРуководителя { get; set; }
    }
}
