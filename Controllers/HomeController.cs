using System.Diagnostics;
using ABC_Retail_ST10255912_POE.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABC_Retail_ST10255912_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            // Add logic to save the email to your database or mailing list
            TempData["Message"] = "Thank you for subscribing!";
            return RedirectToAction("Index");
        }

    }
}
