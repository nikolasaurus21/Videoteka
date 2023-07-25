using System.Linq;
using System.Web.Http;
using Videoteka.Models;
using Videoteka.DTOs;


namespace Videoteka.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult NewRental(RentalDTO rentalDTO)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == rentalDTO.CustomerId);
            var movie = _context.Movies.FirstOrDefault(m => m.Id == rentalDTO.MovieId);

            if (customer == null || movie == null)
            {
                return BadRequest("Nepostojeći kupac ili film.");
            }

            if (movie.NumberAvailable == 0)
            {
                return BadRequest("Film nije dostupan za iznajmljivanje.");
            }


            var rent = new Rent
            {
                CustomerId = rentalDTO.CustomerId,
                MovieId = rentalDTO.MovieId,
                RentDate= rentalDTO.RentDate,
                Note = rentalDTO.Note
            };

            movie.NumberAvailable--;

            _context.Rentals.Add(rent);

            _context.SaveChanges(); 

            return Ok(new { message = "Film je uspješno iznajmljen." });
        }
    }
}
