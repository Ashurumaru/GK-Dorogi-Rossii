//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Новости
    {
        public int НовостьID { get; set; }
        public string Заголовок { get; set; }
        public string Содержание { get; set; }
        public System.DateTime ДатаСоздания { get; set; }
        public int СозданоПользователемID { get; set; }
    
        public virtual Пользователи Пользователи { get; set; }
    }
}
