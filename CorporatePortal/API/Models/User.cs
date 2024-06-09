using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string patronymic { get; set; }
        public string Email { get; set; }
        public Nullable<int> idRole { get; set; }
        public Nullable<int> idDepartment { get; set; }
        public Nullable<int> idPosition { get; set; }
        public string workNumber { get; set; }
        public string homeNumber { get; set; }
        public Nullable<System.DateTime> birthDay { get; set; }
        public string photoPath { get; set; }
        public Nullable<int> idSwapper { get; set; }
    }

}

