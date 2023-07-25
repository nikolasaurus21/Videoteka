using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Videoteka.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public DateTime DateAddedInDb { get; set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime RentDate { get; set; }
        [Range(1, 20)]
        [Required]
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}