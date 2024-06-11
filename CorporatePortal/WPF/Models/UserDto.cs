using System;

namespace CorporatePortal.WPF.Models
{
    public class UserDto
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public int? IdDepartment { get; set; }
        public string DepartmentName { get; set; }
        public int? IdPosition { get; set; }
        public string PositionName { get; set; }
        public string WorkNumber { get; set; }
        public string HomeNumber { get; set; }
        public DateTime? BirthDay { get; set; }
        public string PhotoPath { get; set; }
        public int? IdSwapper { get; set; }
    }
}
