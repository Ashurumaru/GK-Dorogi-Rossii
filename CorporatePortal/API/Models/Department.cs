namespace API.Models
{
    public class Department
    {
        public int ПодразделениеID { get; set; } 
        public string НазваниеПодразделения { get; set; }
        public int? РуководительПодразделения { get; set; }
        public int? ПомощникРуководителя { get; set; } 
    }
}
