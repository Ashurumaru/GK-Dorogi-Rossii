using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class EventType
    {
        [Key]
        public int idTypeEvent { get; set; }
        public string nameType { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
