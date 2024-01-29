using Microsoft.AspNetCore.Mvc;
using prjMyDB.Models;
using System.Text;

namespace prjMyDB.Controllers
{
    public class ApiController : Controller
    {

        private readonly MyDBContext _dbContext;

        public ApiController(MyDBContext dbContext)

        {

            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Index()
        {
            return Content("Chio \n 嗨 \n ", "text/plain", Encoding.UTF8);
        }
        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        public IActionResult Avatar(int id = 1)
        {
            Member? member = _dbContext.Members.Find(id);
            if (member != null)
            {
                byte[] img = member.FileData;
                if (img != null)
                {
                    return File(img, "image/jpeg");
                }
            }
            return NotFound();
        }
    }
}
