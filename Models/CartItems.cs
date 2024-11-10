using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class CartItems
    {
        [Key]
        public int CartItemsID { get; set; }
        [Required]
        public string CartID { get; set; }
        [Required]
        public string ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
