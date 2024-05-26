namespace CarRental.Entities
{
    public class CatalogComment : BaseEntity
    {
        public string Content { get; set; }

        public int CatalogId { get; set; }

        public Catalog Catalog { get; set; } = null!;
    }
}
