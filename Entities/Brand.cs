namespace CarRental.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }


        public ICollection<Model> Models { get; } = new List<Model>();
    }
}
