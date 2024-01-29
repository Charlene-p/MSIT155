using appAsync.Models;
using Microsoft.AspNetCore.Mvc;

namespace appAsync.Controllers
{
    public class HomeworkController : Controller
    {

        private readonly MyDbContext _dbContext;

        public HomeworkController(MyDbContext dbContext)

        {

            _dbContext = dbContext;
        }
        public IActionResult Cities() {
            var cities = _dbContext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
        
    }
}
