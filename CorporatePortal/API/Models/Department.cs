using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Department
    {
        [Key]
        public int idDepartrment { get; set; }
        public string nameDepartment { get; set; }
        public int? idDirectorDepartment { get; set; }
        public int? idSupportDirectorDepartment { get; set; }
        public int? idParentDepartment { get; set; }

        [ForeignKey("idDirectorDepartment")]
        public virtual User Director { get; set; }

        [ForeignKey("idSupportDirectorDepartment")]
        public virtual User SupportDirector { get; set; }

        [ForeignKey("idParentDepartment")]
        public virtual Department ParentDepartment { get; set; }
    }
}
