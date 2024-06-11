using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Event
    {
        [Key]
        public int idEvent { get; set; }
        public string nameEvent { get; set; }
        public int? idTypeEvent { get; set; }
        public int? idStatusEvent { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string descriptionEvent { get; set; }
        public int? idInitiator { get; set; }

        [ForeignKey("idTypeEvent")]
        public virtual EventType EventType { get; set; }

        [ForeignKey("idStatusEvent")]
        public virtual EventStatus EventStatus { get; set; }

        [ForeignKey("idInitiator")]
        public virtual User Initiator { get; set; }
    }
}
