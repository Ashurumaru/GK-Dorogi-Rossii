using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models;

namespace CorporatePortal.WPF.Models
{
    public class User
    {
        public int idUser { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string patronymic { get; set; }
        public string Email { get; set; }
        public int? idDepartment { get; set; }
        public int? idPosition { get; set; }
        public string workNumber { get; set; }
        public string homeNumber { get; set; }
        public DateTime birthDay { get; set; }
        public string photoPath { get; set; }
        public int? idSwapper { get; set; }

        public Department Department { get; set; }
        public UserPosition Position { get; set; }
    }
}
