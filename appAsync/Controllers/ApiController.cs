using appAsync.Models;
using appAsync.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace appAsync.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _dbContext;
        private IWebHostEnvironment _environment;
        public ApiController(MyDBContext dbContext, IWebHostEnvironment environment)
        {

            _dbContext = dbContext;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
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
        public IActionResult Districts(String city)
        {
            var districts = _dbContext.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
        }
        public IActionResult Roads(String district)
        {
            var roads = _dbContext.Addresses.Where(a => a.SiteId == district).Select(a => a.Road).Distinct();
            return Json(roads);
        }

        //public IActionResult Register(string name, int age = 20)
        [HttpPost]
        public IActionResult Register(UserDTO _user)
        {
            if (string.IsNullOrEmpty(_user.Name))
            {
                _user.Name = "guest";
            }

            string info = $"{_user.Avatar.FileName} - {_user.Avatar.Length} - {_user.Avatar.ContentType}";
            string filePath = Path.Combine(_environment.WebRootPath, "uploads", _user.Avatar.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create)) 
            { 
                _user.Avatar.CopyTo(fileStream);
            }
            
            return Content(info);
            //return Content($"嗨 {_user.Name}, 你今年 {_user.Age} 歲了!");
        }

        public IActionResult CheckAccount(string name)
        {
            var member = _dbContext.Members.Any(a => a.Name == name);
            if (member)
            {
                return Content($"帳號已存在 {member}");
            }
            else
                return Content("帳號可使用");
        }
        public IActionResult ShowData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Spots([FromBody]SearchDTO _spot) {

            return Json(_spot);
        }

    }
}
