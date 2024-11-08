using Microsoft.AspNetCore.Identity;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        // Link to Identity User
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        // Navigation property
        public ICollection<Order>? Orders { get; set; }
    }

}
