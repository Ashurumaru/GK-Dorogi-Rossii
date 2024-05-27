namespace API.Models
{
    public class User
    {
        public int ПользовательID { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Отчество { get; set; }
        public string ЭлПочта { get; set; }
        public int РольID { get; set; }
        public int? ПодразделениеID { get; set; } 
        public string Должность { get; set; }
        public string РабочийТелефон { get; set; }
        public string ДомашнийТелефон { get; set; }
        public DateTime? ДатаРождения { get; set; } 
        public int? РуководительID { get; set; }
        public string? ПутьКФото { get; set; }
        public int? ЗаменяющийID { get; set; } 
    }

}

