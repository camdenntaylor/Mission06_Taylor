using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Taylor.Models;

namespace Mission06_Taylor.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            _context.Movies.Add(response); // add record to database
            _context.SaveChanges(); //commit

            return View("Confirmation", response);
        }
    }
}
