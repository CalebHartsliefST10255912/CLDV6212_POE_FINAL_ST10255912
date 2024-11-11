using ABC_Retail_ST10255912_POE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class OrderItem
    {

        public int OrderItemID { get; set; }


        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public string FormattedPrice
        {
            get
            {
                return $"R{Price:N2}";
            }
        }

        //Navigation Properties
        public virtual Order Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
