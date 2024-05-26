using CarRental.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Contexts
{
    public class AppIdentityContext : IdentityDbContext<User>
    {
        public AppIdentityContext(DbContextOptions options) : base(options)
        {
            
        }

        public override int SaveChanges()
        {

            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is User && (e.State == EntityState.Modified || e.State == EntityState.Added));

            foreach (var item in entries)
            {
                ((User)item.Entity).UpdatedDate = DateTime.Now;
                if (item.State == EntityState.Added)
                {
                    ((User)item.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
