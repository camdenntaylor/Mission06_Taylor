using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Taylor.Models;
using Microsoft.EntityFrameworkCore;

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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new Movie());
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // add record to database
                _context.SaveChanges(); //commit

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View(response);
            }
            
        }


        //Get MovieList view and pass data from movies table
        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        // Get route to edit movies in the database. Populates Add movie form with existing movie data
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie updatedInfo)
            
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id) 
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View("Delete", recordToDelete);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie deletedMovie)
        {
            _context.Movies.Remove(deletedMovie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
