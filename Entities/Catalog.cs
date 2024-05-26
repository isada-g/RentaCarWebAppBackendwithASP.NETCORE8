namespace CarRental.Entities
{
    public class Catalog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsRented { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; } = null!;
        public ICollection<CatalogComment> Comments { get; } = new List<CatalogComment>();
    }
}
