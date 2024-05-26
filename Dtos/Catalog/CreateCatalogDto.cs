namespace CarRental.Dtos.Catalog
{
    public class CreateCatalogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime StartDate { get; set; }

        public int UserId { get; set; }
        public int CarId { get; set; }
    }
}
