using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string ?Rating { get; set; }
        [Required]
        public string ?Comment { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }
    }
}
