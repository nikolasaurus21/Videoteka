using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Videoteka.Controllers
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
       
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(x=> x.Genre).Select(x=> new MovieViewModel
            {
                Id= x.Id,
                Title= x.Title,
                DateOfMovie=x.RentDate,
                DateAddedInDb=x.DateAddedInDb,
                NumberAvailable= x.NumberAvailable,
                NumberInStock= x.NumberInStock,
                GenreName = x.Genre.Name
            }).ToList();

            return View(movies);
        }


        public ActionResult New()
        {
            var viewModel = new MovieViewModel();
            ViewBag.Genres = _context.Genres.ToList();
            return View(viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Title = viewModel.Title,
                    DateAddedInDb = DateTime.Now,
                    RentDate = viewModel.DateOfMovie,
                    NumberInStock = viewModel.NumberInStock,
                    NumberAvailable = viewModel.NumberInStock,
                    GenreId = viewModel.GenreId
                };

                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Genres = _context.Genres.ToList();
            return View("New", viewModel);
        }
        
        public ActionResult Edit(int id)
        {
            
            var movie =     _context.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            
            var viewModel = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                DateOfMovie = movie.RentDate,
                NumberInStock = movie.NumberInStock,
                GenreId = movie.GenreId
               
            };

           
            ViewBag.Genres = new SelectList(_context.Genres, "Id", "Name");

            return View(viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                
                ViewBag.Genres = new SelectList(_context.Genres, "Id", "Name");
                return View(viewModel);
            }

            
            var movie = _context.Movies.Find(viewModel.Id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            
            movie.Title = viewModel.Title;
            movie.RentDate = viewModel.DateOfMovie;
            movie.NumberInStock = viewModel.NumberInStock;
            movie.GenreId = viewModel.GenreId;

            
            _context.SaveChanges();

            return RedirectToAction("Index");



        }
        
        public ActionResult Delete(int id)
            {

                var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);

                if (movie == null)
                {
                    return HttpNotFound();
                }
            var movieVm = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                DateOfMovie = movie.RentDate,
                DateAddedInDb = movie.DateAddedInDb,
                GenreName = movie.Genre.Name,
                NumberAvailable = movie.NumberAvailable,
                NumberInStock= movie.NumberInStock,
            };

            return View(movieVm);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                var movie = _context.Movies.Find(id);

                if (movie == null)
                {
                    return HttpNotFound();
                }

                _context.Movies.Remove(movie);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
    }
}