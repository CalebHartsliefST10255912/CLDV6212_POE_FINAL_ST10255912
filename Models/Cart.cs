using ABC_Retail_ST10255912_POE.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string? UserID { get; set; }

        //Navigation Properties

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public virtual IdentityUser? User { get; set; }
    }
}
