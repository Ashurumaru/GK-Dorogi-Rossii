using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UserPosition
    {
        [Key]
        public int idPosition { get; set; }
        public string namePosition { get; set; }

        //public virtual ICollection<User> Users { get; set; }
    }
}
