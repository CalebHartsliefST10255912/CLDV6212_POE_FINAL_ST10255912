using ABC_Retail_ST10255912_POE.Data;
using ABC_Retail_ST10255912_POE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABC_Retail_ST10255912_POE.Controllers
{
    public class OrdersController : Controller
    {
        private List<Order> GetFakeOrders()
        {
            return new List<Order>
            {
                new Order { OrderId = 1, OrderDate = DateTime.Now, CustomerId = 1, ProductId = 1, Quantity = 2 },
                new Order { OrderId = 2, OrderDate = DateTime.Now, CustomerId = 2, ProductId = 2, Quantity = 1 }
            };
        }

        public IActionResult Index()
        {
            var orders = GetFakeOrders();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = GetFakeOrders().Find(o => o.OrderId == id);
            if (order == null) return NotFound();
            return View(order);
        }
    }
}