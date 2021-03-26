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

        //Create a private context to hold the list of movie objects
        private MovieDbContext _context { get; set; }
        
        //Set the context equal to the DbContext passed into the constructor
        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
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

        //Submits the form and adds new movie to the database
        public IActionResult SubmitForm(MovieInfo movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            return View("Output", _context.Movies);
        }
        //Output Movie Data page view function
        public IActionResult Output()
        {
            return View(_context.Movies);
        }

        //Method to remove a movie
        public IActionResult DeleteMovie(int MovieId)
        {
            MovieInfo selectedMovie = _context.Movies.Where(m => m.MovieId == MovieId).FirstOrDefault();
            
            _context.Remove(selectedMovie);
            _context.SaveChanges();

            return View("Output", _context.Movies);
        }

        //Method to edit a movie's information (edit form)
        public IActionResult EditMovie(int MovieId)
        {
            //Query to get selected movie object and pass it to update view
            MovieInfo selectedMovie = _context.Movies.Where(m => m.MovieId == MovieId).FirstOrDefault();
            return View(selectedMovie);
        }

        //Method to update a movie's information (save changes to an edited movie)
        public IActionResult UpdateMovie(MovieInfo movie)
        {
            _context.Update(movie);
            _context.SaveChanges();

            return View("Output", _context.Movies);
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
