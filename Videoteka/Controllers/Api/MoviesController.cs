using System.Linq;
using System.Web.Http;
using Videoteka.DTOs;
using Videoteka.Models;


namespace Videoteka.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


       
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.Where(x => x.NumberAvailable>0).Select(x => new MovieDTO
            {
                Id = x.Id,
                Name=x.Title
            }).ToList();

            return Ok(movies);
        }

        

    }
}


   
