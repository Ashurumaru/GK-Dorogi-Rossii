using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class UserAccount
    {
        [Key]
        public int idUserAccount { get; set; }
        [ForeignKey("User")]
        public int? idUser { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string passwordHash { get; set; }
        [ForeignKey("UserRole")]
        public int? idRole { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public UserRole UserRole { get; set; }
    }

}
