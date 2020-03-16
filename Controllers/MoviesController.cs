using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Correct.Models;
using Vidly_Correct.ViewModels;

namespace Vidly_Correct.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            var movieViewModel = new MovieFormViewModel
            {
                GenreList = _context.Genres.ToList()
            };
            return View("MoviesForm", movieViewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var movieViewModel = new MovieFormViewModel(movie)
            {
                GenreList = _context.Genres.ToList()
            };

            return View("MoviesForm", movieViewModel);
        }
            


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var movieView = new MovieFormViewModel(movie)
                {
                    GenreList = _context.Genres.ToList()
                };
                return View("MoviesForm", movieView);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.UtcNow;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index", "Movies");
        }

       
    }
}