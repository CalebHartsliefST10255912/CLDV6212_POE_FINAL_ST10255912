using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Categories
    {
        [Key]
        public string CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
