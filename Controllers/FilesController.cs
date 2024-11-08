using ABC_Retail_ST10255912_POE.Data;
using Microsoft.AspNetCore.Mvc;

namespace ABC_Retail_ST10255912_POE.Controllers
{
    public class FilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var files = _context.Files.ToList();
            return View(files);
        }

        public IActionResult Details(int id)
        {
            var file = _context.Files.Find(id);
            if (file == null) return NotFound();
            return View(file);
        }
    }
}
