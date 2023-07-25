using System;
using System.ComponentModel.DataAnnotations;

namespace Videoteka.DTOs
{
    public class RentalDTO
    {
        [Required(ErrorMessage = "Morate unijeti kupca.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Morate unijeti film.")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Morate unijeti datum iznajmljivanja.")]
        public DateTime RentDate { get; set; }

        public string Note { get; set; }
    }
}
