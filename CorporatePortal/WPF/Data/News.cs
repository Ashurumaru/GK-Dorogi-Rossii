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
    
    public partial class News
    {
        public int idNew { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> idCreator { get; set; }
    
        public virtual Users Users { get; set; }
    }
}