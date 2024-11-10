using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Carts
    {
        [Key]
        public string CartID { get; set; }
        [Required]
        public string CustomerID { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
