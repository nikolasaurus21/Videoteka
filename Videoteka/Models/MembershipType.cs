using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public int MembershipFee { get; set; }
        public int Discount { get;set; }
        [Required]
        [MaxLength(50)]
        
        public string Name { get; set; }
        [Required]
        public int MonthlyDuration { get; set; }
    }
}