using CarRental.Contexts;
using CarRental.Dtos.Model;
using CarRental.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Repositores
{
    public class ModelRepository
    {
        private readonly AppDbContext _context;

        public ModelRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Model> GetModels()
        {
            return _context.Models.ToList();
        }

        public Model GetModel(int id)
        {
            return _context.Models.FirstOrDefault(x => x.ID == id);
        }

        public bool AddModel(CreateModelDto modelDto)
        {
            if (modelDto.Name != null)
            {
                var brand = _context.Brands.FirstOrDefault(x => x.ID == modelDto.BrandId);
                if (brand != null)
                {
                    var model = new Model
                    {
                        Name = modelDto.Name,
                        ReleaseDate = modelDto.ReleaseDate,
                        FuelType = modelDto.FuelType,
                        GearType = modelDto.GearType,
                        BrandId = brand.ID,
                        Brand = brand,
                        ImageUrl = modelDto.ImageUrl,
                        IsActive = true // Assuming new models are active by default
                    };
                    _context.Models.Add(model);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteModel(int id)
        {
            var model = GetModel(id);
            if (model != null)
            {
                _context.Models.Remove(model);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateModel(int id, Model updatedModel)
        {
            var existingModel = GetModel(id);
            if (existingModel != null)
            {
                existingModel.Name = updatedModel.Name;
                existingModel.ImageUrl = updatedModel.ImageUrl;
                existingModel.FuelType = updatedModel.FuelType;
                existingModel.GearType = updatedModel.GearType;
                existingModel.BrandId = updatedModel.BrandId;
                existingModel.IsActive = updatedModel.IsActive;

                _context.Models.Update(existingModel);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
