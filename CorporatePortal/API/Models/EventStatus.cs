using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class EventStatus
    {
        [Key]
        public int idStatusEvent { get; set; }
        public string nameStatus { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
