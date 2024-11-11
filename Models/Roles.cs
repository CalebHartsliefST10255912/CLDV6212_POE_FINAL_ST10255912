using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string ?RoleName { get; set; }
    }
}
