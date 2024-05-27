using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePortal.WPF.Models
{
    internal class ResponseUser
    {
        public ResponseUser(int пользовательID, string логин, string пароль, string имя, string фамилия, string отчество, string элПочта, int рольID, int? подразделениеID, string должность, string рабочийТелефон, string домашнийТелефон, DateTime? датаРождения, int? руководительID, byte[] фото, int? заменяющийID)
        {
            ПользовательID = пользовательID;
            Логин = логин;
            Пароль = пароль;
            Имя = имя;
            Фамилия = фамилия;
            Отчество = отчество;
            ЭлПочта = элПочта;
            РольID = рольID;
            ПодразделениеID = подразделениеID;
            Должность = должность;
            РабочийТелефон = рабочийТелефон;
            ДомашнийТелефон = домашнийТелефон;
            ДатаРождения = датаРождения;
            РуководительID = руководительID;
            Фото = фото;
            ЗаменяющийID = заменяющийID;
        }

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
        public byte[] Фото { get; set; }
        public Nullable<int> ЗаменяющийID { get; set; }
    }
}
