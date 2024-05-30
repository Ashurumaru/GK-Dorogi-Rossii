using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporatePortal.WPF.Models;
using WPF.Data;
namespace WPF.Models
{
    public class Event
    {
        public int МероприятиеID { get; set; }
        public string НазваниеМероприятия { get; set; }
        public string ТипМероприятия { get; set; }
        public string СтатусМероприятия { get; set; }
        public DateTime ДатаНачала { get; set; }
        public DateTime ДатаОкончания { get; set; }
        public string КраткоеОписание { get; set; }
        public string Инициатор { get; set; }
        public virtual ICollection<Responsible> Ответственные { get; set; }
    }
}
