using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string patronymic { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public int? idDepartment { get; set; }
        public int? idPosition { get; set; }
        public string workNumber { get; set; }
        public string homeNumber { get; set; }
        public DateTime birthDay { get; set; }
        public string photoPath { get; set; }
        public int? idSwapper { get; set; }
        [JsonIgnore]
        public ICollection<UserAccount> UserAccounts { get; set; }

    }

}

