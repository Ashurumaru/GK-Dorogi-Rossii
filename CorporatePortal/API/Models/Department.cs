using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Department
    {
        [Key]
        public int ПодразделениеID { get; set; } 
        public string НазваниеПодразделения { get; set; }
        public int? РуководительПодразделения { get; set; }
        public int? ПомощникРуководителя { get; set; } 
    }
}
