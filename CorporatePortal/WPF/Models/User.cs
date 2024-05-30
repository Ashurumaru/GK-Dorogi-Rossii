using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePortal.WPF.Models
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
        public Nullable<int> ПодразделениеID { get; set; }
        public string Должность { get; set; }
        public string РабочийТелефон { get; set; }
        public string ДомашнийТелефон { get; set; }
        public Nullable<System.DateTime> ДатаРождения { get; set; }
        public Nullable<int> РуководительID { get; set; }
        public Nullable<int> ЗаменяющийID { get; set; }
        public string ПутьКФото { get; set; }
    }
}
