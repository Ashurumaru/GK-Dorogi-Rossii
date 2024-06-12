using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    public class EventsItem
    {
        public string NameEvent { get; set; }
        public int IdTypeEvent { get; set; }
        public int IdStatusEvent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DescriptionEvent { get; set; }
    }
}
