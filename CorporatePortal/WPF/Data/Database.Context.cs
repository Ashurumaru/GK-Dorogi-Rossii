﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CorporatePortalEntities : DbContext
    {
        public CorporatePortalEntities()
            : base("name=CorporatePortalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Документы> Документы { get; set; }
        public virtual DbSet<Мероприятия> Мероприятия { get; set; }
        public virtual DbSet<Новости> Новости { get; set; }
        public virtual DbSet<ОтветственныеЗаДокумент> ОтветственныеЗаДокумент { get; set; }
        public virtual DbSet<ОтветственныеЗаМероприятие> ОтветственныеЗаМероприятие { get; set; }
        public virtual DbSet<Подразделения> Подразделения { get; set; }
        public virtual DbSet<Пользователи> Пользователи { get; set; }
        public virtual DbSet<Проекты> Проекты { get; set; }
        public virtual DbSet<Роли> Роли { get; set; }
        public virtual DbSet<СобытияОтсутствия> СобытияОтсутствия { get; set; }
        public virtual DbSet<СогласующиеДокумент> СогласующиеДокумент { get; set; }
        public virtual DbSet<СтатусыДокументов> СтатусыДокументов { get; set; }
        public virtual DbSet<СтатусыМероприятий> СтатусыМероприятий { get; set; }
        public virtual DbSet<ТипыДокументов> ТипыДокументов { get; set; }
        public virtual DbSet<ТипыМероприятий> ТипыМероприятий { get; set; }
        public virtual DbSet<УчастникиМероприятия> УчастникиМероприятия { get; set; }
        public virtual DbSet<ЭтапыДокументов> ЭтапыДокументов { get; set; }
        public virtual DbSet<ЭтапыПроектов> ЭтапыПроектов { get; set; }
    }
}