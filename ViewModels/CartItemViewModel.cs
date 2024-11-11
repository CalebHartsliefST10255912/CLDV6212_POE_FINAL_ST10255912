namespace ABC_Retail_ST10255912_POE.ViewModels
{
    public class CartItemViewModel
    {
        public string ?CartItemID { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string FormattedPrice
        {
            get
            {
                return $"R{Price:N2}";
            }
        }
        public string? ImagePath { get; set; }
    }
}
