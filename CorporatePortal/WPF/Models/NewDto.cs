using System;


namespace CorporatePortal.WPF.Models
{
    public class NewDto
    {
        public int IdNew { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int? IdTypeNew { get; set; }
        public string NameTypeNew { get; set; }
        public int? IdCreator { get; set; }
        public string Creator { get; set;}
    }
}
