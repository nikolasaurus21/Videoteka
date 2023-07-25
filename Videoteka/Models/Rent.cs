using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Rent
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Note { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        
        public DateTime RentDate { get; set; }
        
        public DateTime? ReturnDate { get; set; }

        public Movie Movie { get; set; }
        public Customer Customer { get; set; }
    }
}