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

        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }


        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<New> News { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Department)
            //    .WithMany()
            //    .HasForeignKey(u => u.idDepartment)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Director)
                .WithOne()
                .HasForeignKey<Department>(d => d.idDirectorDepartment)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.SupportDirector)
                .WithOne()
                .HasForeignKey<Department>(d => d.idSupportDirectorDepartment)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.ParentDepartment)
                .WithMany()
                .HasForeignKey(d => d.idParentDepartment)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserAccounts)
                .WithOne()
                .HasForeignKey(ua => ua.idUser);
        }
    }

}
