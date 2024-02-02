using appAsync.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace appAsync.Controllers
{
    public class HomeworkController : Controller
    {

        private readonly MyDBContext _dbContext;

        public HomeworkController(MyDBContext dbContext)

        {

            _dbContext = dbContext;
        }

        //[HttpPost]
        public IActionResult Index() {
            Thread.Sleep(5000);
            return Content("Chio \n 嗨 \n ", "text/plain", Encoding.UTF8);
        }

        public IActionResult ErrorTest() { 
            int a = 0;
            int b = 1;
            int c = b/a;
            return Content("Error Testing", "text/plain");
        }






        
    }
}
