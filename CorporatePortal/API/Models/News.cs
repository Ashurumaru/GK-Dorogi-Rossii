using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace API.Models
{
    public class News
    {
        public int НовостьID { get; set; }
        public string Заголовок { get; set; }
        public string Содержание { get; set; }
        public DateTime ДатаСоздания { get; set; } = DateTime.Now;
        public int СозданоПользователемID { get; set; }

        public User СозданоПользователем { get; set; }
    }
}