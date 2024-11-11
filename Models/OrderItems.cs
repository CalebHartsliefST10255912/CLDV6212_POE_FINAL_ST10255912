using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public string ?ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal PriceAtPurchase { get; set; }
    }
}
