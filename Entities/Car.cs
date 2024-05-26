namespace CarRental.Entities
{
    public class Car : BaseEntity
    {
        public string License { get; set; }
        public long Km { get; set; }
        public int ModelId { get; set; }

        public Model Model { get; set; } = null!;
    }
}
