using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Net.Http;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet]
         public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync("http://servhost/api/Test");

            ViewBag.Response = result;


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
    }
}
