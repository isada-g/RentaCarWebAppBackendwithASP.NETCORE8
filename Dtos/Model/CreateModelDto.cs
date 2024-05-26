using CarRental.Entities;
using System;

namespace CarRental.Dtos.Model
{
    public class CreateModelDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public FuelTypes FuelType { get; set; }
        public GearTypes GearType { get; set; }
        public int BrandId { get; set; }
    }
}
