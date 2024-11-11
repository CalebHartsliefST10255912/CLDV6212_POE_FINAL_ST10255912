using ABC_Retail_ST10255912_POE.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }

        //Navigation Properties
        public virtual Products Products { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
