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


        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<New> News { get; set; }
    }

}
