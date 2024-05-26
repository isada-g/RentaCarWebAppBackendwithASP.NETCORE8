using CarRental.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<Catalog> Catalogs{ get; set; }
        public DbSet<CatalogComment> CatalogComments { get; set; }
        public DbSet<Model> Models { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public override int SaveChanges()
        {

            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Modified || e.State == EntityState.Added));

            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity).UpdatedDate = DateTime.Now;
                if (item.State == EntityState.Added)
                {
                    ((BaseEntity)item.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>()
                .HasMany(e => e.Cars)
                .WithOne(e => e.Model)
                .HasForeignKey(e => e.ModelId)
                .IsRequired();

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Models)
                .WithOne(e => e.Brand)
                .HasForeignKey(e => e.BrandId)
                .IsRequired();

        }
    }
}
