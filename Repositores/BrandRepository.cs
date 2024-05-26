using CarRental.Contexts;
using CarRental.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace CarRental.Repositores
{
    public class BrandRepository
    {
        AppDbContext context;

        public BrandRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Brand> GetBrands()
        {
            return context.Brands.ToList();
        }

        public Brand GetBrand(int id)
        {
            return context.Brands.Where(x => x.ID == id).FirstOrDefault();
        }

        public bool AddBrand(Brand brand) 
        {
            if (brand.Name != null)
            {
                context.Brands.Add(brand);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteBrand(int id)
        {
            Brand brand = GetBrand(id);
            if (brand != null)
            {
                context.Brands.Remove(brand);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateBrand(int id,Brand brand)
        {
            Brand dbBrand = GetBrand(id);
            if (dbBrand != null)
            {
                dbBrand.Name = brand.Name;
                dbBrand.IsActive = brand.IsActive;
                dbBrand.ImageUrl = brand.ImageUrl;
                context.Brands.Update(dbBrand);
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
