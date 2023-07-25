using System;
using System.ComponentModel.DataAnnotations;

namespace Videoteka.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je obavezno polje.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Prima obavještenja")]
        public bool Notifications { get; set; }

        [Display(Name = "Datum rođenja")]
        [Required(ErrorMessage = "Datum rođenja je obavezno polje.")]
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        
        [Display(Name = "Tip članstva")]
        [Required(ErrorMessage = "Tip članstva je obavezno polje.")]
        public int MembershipTypeId { get; set; }

        [Display(Name = "Tip kupca")]
        [Required(ErrorMessage = "Tip kupca je obavezno polje.")]
        public int CustomerTypeId { get; set; }
        public string MembershipTypeName { get; set; }
        public string CustomerTypeName { get; set; }
    }
}
