using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UserRole
    {
        [Key]
        public int idRole { get; set; }
        public string nameRole { get; set; }
    }
}
