using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CorporatePortalContext : DbContext
    {
        public CorporatePortalContext(DbContextOptions<CorporatePortalContext> options)
            : base(options)
        {
        }

        public DbSet<User> Пользователи { get; set; }
        public DbSet<Role> Роли { get; set; }
        public DbSet<Department> Подразделения { get; set; }
        public DbSet<News> Новости { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.ПользовательID);
            modelBuilder.Entity<Role>().HasKey(r => r.РольID);
            modelBuilder.Entity<Department>().HasKey(d => d.ПодразделениеID);
            modelBuilder.Entity<News>().HasKey(n => n.НовостьID);


            base.OnModelCreating(modelBuilder);
        }

    }

}
