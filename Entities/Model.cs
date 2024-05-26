using Microsoft.EntityFrameworkCore;

namespace CarRental.Entities
{
    public enum FuelTypes
    {
        Diesel,
        Petrol
    }

    public enum GearTypes 
    {
        Manuel,
        Automatic
    }

    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public FuelTypes FuelType { get; set; }
        public GearTypes GearType { get; set; }
        public int BrandId { get; set; }


        public Brand Brand { get; set; } = null!;
        public ICollection<Car> Cars { get; } = new List<Car>();

        
    }
}
