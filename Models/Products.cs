using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Products
    {
        [Key]
        public string ?ProductID { get; set; }
        [Required]
        public string ?Title { get; set; }
        [Required]
        public string ?Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string ?ImagePath { get; set; }

        public bool OnSale { get; set; }
    }
}
