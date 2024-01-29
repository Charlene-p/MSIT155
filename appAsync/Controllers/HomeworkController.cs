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

        public IActionResult Register(string name, int age = 20) {
            if (string.IsNullOrEmpty(name)) 
            {
                name = "guest";
            }
            return Content($"Hello {name}, You are {age} years old!");
        }

        public IActionResult CheckAccount(string name)
        {
            var member = _dbContext.Members.FirstOrDefault(a=>a.Name == name);
            if (member != null) {
                return Content($"帳號已存在 {member.Name}");
            }
            else 
                return Content("帳號可使用");


        }
        public IActionResult Cities() {
            var cities = _dbContext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        public IActionResult Avatar(int id=1)
        {
            Member? member = _dbContext.Members.Find(id);
            if(member != null)
            {
                byte[] img = member.FileData;
                if(img != null)
                {
                    return File(img, "image/jpeg");
                }
            }
            return NotFound();
        }
        
    }
}
