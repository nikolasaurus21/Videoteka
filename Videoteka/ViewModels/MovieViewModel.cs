using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Naziv filma")]
        [Required(ErrorMessage = "Naslov je obavezno polje.")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum unosa")]
        [Required(ErrorMessage = "Datum unosa u bazu je obavezno polje.")]
        public DateTime DateAddedInDb { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum filma")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Datum filma je obavezno polje.")]
        public DateTime DateOfMovie { get; set; }

        [Range(1, 20, ErrorMessage = "Broj na stanju mora biti između 1 i 20.") ]
        [Required(ErrorMessage = "Na stanju je obavezno polje.")]
        [Display(Name = "Na stanju")]
        public int NumberInStock { get; set; }

        [Display(Name = "Dostupnih")]
        public int NumberAvailable { get; set; }

        [Required(ErrorMessage = "Žanr je obavezno polje.")]
        [Display(Name = "Žanr")]
        public int GenreId { get; set; }

        public string GenreName { get; set; }   
    }
}
