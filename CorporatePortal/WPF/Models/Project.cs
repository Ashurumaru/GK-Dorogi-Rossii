using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePortal.WPF.Models
{
    public class Project
    {
        public int ПроектID { get; set; }
        public string НазваниеПроекта { get; set; }
        public string ОписаниеПроекта { get; set; }
        public System.DateTime ДатаНачала { get; set; }
        public Nullable<System.DateTime> ДатаОкончания { get; set; }
        public int РуководительПроектаID { get; set; }
        public string Статус { get; set; }
    }
}
