using CarRental.Contexts;
using CarRental.Dtos.Catalog;
using CarRental.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace CarRental.Repositores
{
    public class CatalogRepository
    {
        AppDbContext context;

        public CatalogRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Entities.Catalog> GetCatalogs()
        {
            return context.Catalogs
                .Include(c => c.Car)
                .ThenInclude(car => car.Model)
                .ThenInclude(model => model.Brand)
                .ToList();
        }

        public Entities.Catalog GetCatalog(int id)
        {
            return context.Catalogs
                .Include(c => c.Car)
                .ThenInclude(car => car.Model)
                .ThenInclude(model => model.Brand)
                .FirstOrDefault(c => c.ID == id);
        }

        public bool AddCatalog(CreateCatalogDto Catalog)
        {
            if (Catalog.Title != null)
            {
                Car car = context.Cars.Where(x => x.ID == Catalog.CarId).FirstOrDefault();
                if (car != null)
                {
                    Entities.Catalog catalog = new Entities.Catalog();
                    catalog.Title = Catalog.Title;
                    catalog.Car = car;
                    catalog.CarId = Catalog.CarId;
                    catalog.Price = Catalog.Price;
                    catalog.Description = Catalog.Description;

                    context.Catalogs.Add(catalog);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteCatalog(int id)
        {
            Entities.Catalog Catalog = GetCatalog(id);
            if (Catalog != null)
            {
                context.Catalogs.Remove(Catalog);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCatalog(int id, Entities.Catalog catalog)
        {
            Entities.Catalog dbCatalog = GetCatalog(id);
            if (dbCatalog != null)
            {
                dbCatalog.Title = catalog.Title;
                dbCatalog.Price = catalog.Price;
                dbCatalog.Description = catalog.Description;
                context.Catalogs.Update(dbCatalog);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
