using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
