using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int РольID { get; set; }
        public string НазваниеРоли { get; set; }
    }
}
