using System.Linq;
using System.Web.Http;
using Videoteka.Models;
using Videoteka.DTOs;

namespace Videoteka.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context= new ApplicationDbContext();
        }

       
        public IHttpActionResult GetCustomers() 
        {
            var customers =  _context.Customers.Select(x => new CustomerDTO
            {
                Name = x.Name,
                Id= x.Id,
            }).ToList();

            return Ok(customers);
        }


        

    }
}
