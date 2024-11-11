namespace ABC_Retail_ST10255912_POE.ViewModels
{
    public class CartViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
        public decimal TotalPrice { get; set; }
        public string FormattedTotalPrice
        {
            get
            {
                return $"R{TotalPrice:N2}";
            }
        }
    }
}
