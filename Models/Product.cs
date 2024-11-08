namespace ABC_Retail_ST10255912_POE.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        // Navigation property
        public ICollection<Order>? Orders { get; set; }
    }
}
