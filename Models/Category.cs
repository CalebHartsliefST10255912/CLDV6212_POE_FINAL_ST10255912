using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }


        // Navigation property
        public virtual ICollection<Products> Products { get; set; }
    }
}
