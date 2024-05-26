using Microsoft.AspNetCore.Identity;

namespace CarRental.Entities
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? CreatedDate{ get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
