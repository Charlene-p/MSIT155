using appAsync.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace appAsync.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly NorthwindContext _context;


        public HomeController(ILogger<HomeController> logger, NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult JsonTest()
        {
            return View();
        }


        public IActionResult Index()
        {
            var products = _context.Products.Where(p => p.CategoryId == 1);

            return View(products);
            //return View();
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
    }
}
