using ABC_Retail_ST10255912_POE.Data;
using ABC_Retail_ST10255912_POE.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABC_Retail_ST10255912_POE.Controllers
{
    public class ProductsController : Controller
    {
        // Temporary fake data for products
        private List<Product> GetFakeProducts()
        {
            return new List<Product>
            {
                new Product { ProductId = 1, Name = "Product A", Description = "Description of Product A", Price = 19.99M, ImageUrl = "/images/productA.jpg" },
                new Product { ProductId = 2, Name = "Product B", Description = "Description of Product B", Price = 29.99M, ImageUrl = "/images/productB.jpg" },
                new Product { ProductId = 3, Name = "Product C", Description = "Description of Product C", Price = 39.99M, ImageUrl = "/images/productC.jpg" },
                new Product { ProductId = 4, Name = "Product D", Description = "Description of Product D", Price = 19.99M, ImageUrl = "/images/productA.jpg" },
                new Product { ProductId = 5, Name = "Product E", Description = "Description of Product E", Price = 29.99M, ImageUrl = "/images/productB.jpg" },
                new Product { ProductId = 6, Name = "Product F", Description = "Description of Product F", Price = 39.99M, ImageUrl = "/images/productC.jpg" },
                new Product { ProductId = 7, Name = "Product G", Description = "Description of Product G", Price = 19.99M, ImageUrl = "/images/productA.jpg" },
                new Product { ProductId = 8, Name = "Product H", Description = "Description of Product H", Price = 29.99M, ImageUrl = "/images/productB.jpg" },
                new Product { ProductId = 9, Name = "Product I", Description = "Description of Product I", Price = 39.99M, ImageUrl = "/images/productC.jpg" },
                new Product { ProductId = 10, Name = "Product J", Description = "Description of Product J", Price = 19.99M, ImageUrl = "/images/productA.jpg" },
                new Product { ProductId = 11, Name = "Product K", Description = "Description of Product K", Price = 29.99M, ImageUrl = "/images/productB.jpg" },
                new Product { ProductId = 12, Name = "Product L", Description = "Description of Product L", Price = 39.99M, ImageUrl = "/images/productC.jpg" }
            };
        }

        public IActionResult Index()
        {
            // Use the fake data method to simulate a list of products
            var products = GetFakeProducts();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = GetFakeProducts().Find(p => p.ProductId == id);
            if (product == null) return NotFound();
            return View(product);
        }

    }
}
