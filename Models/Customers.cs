using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string ?FirstName { get; set; }
        [Required]
        public string ?LastName { get; set; }
        [Required]
        public string ?PhoneNum { get; set; }
        [Required]
        public string ?Email { get; set; }
        [Required]
        public string ?Username { get; set; }
        [Required] 
        public string ?Password { get; set; }
        [Required]
        public string ?Address { get; set; }
    }
}
