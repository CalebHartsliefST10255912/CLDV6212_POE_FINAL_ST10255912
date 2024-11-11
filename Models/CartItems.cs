using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class CartItems
    {
        [Key]
        public string ?CartItemID { get; set; }
        [Required]
        public string ?CartID { get; set; }

        [ForeignKey("CartID")]
        public Carts Cart { get; set; }

        [Required]
        public string ?ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Products Product { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
