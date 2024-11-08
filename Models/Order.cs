namespace ABC_Retail_ST10255912_POE.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Customer? Customer { get; set; }
        public Product? Product { get; set; }
    }

}
