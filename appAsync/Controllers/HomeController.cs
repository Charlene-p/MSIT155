﻿using appAsync.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace appAsync.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}