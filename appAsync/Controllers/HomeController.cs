using appAsync.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace appAsync.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly MyDBContext _dbContext;


        public HomeController(ILogger<HomeController> logger, MyDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult JsonTest()
        {
            return View();
        }

        public IActionResult Register() {
            return View();
        }

        public IActionResult Index()
        {

            return View();
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Avatar() {
            return View();
        }
        public IActionResult Cities()
        {
            return View();
        }

        public IActionResult Spots() 
        {
            return View();
        }
        public IActionResult Cors()
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
