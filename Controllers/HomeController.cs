using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Home page view function
        public IActionResult Index()
        {
            return View();
        }

        //Podcasts page view function
        public IActionResult MyPodcasts()
        {
            return View();
        }
        
        //Enter Movie page view function
        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        //Output Movie Data page view function
        public IActionResult Output(MovieInfo movieInfo)
        {
            TempStorage.AddMovie(movieInfo);
            return View(TempStorage.Movies.Where(m => m.Title != "Independence Day"));
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
