using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppsLab5.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        [Required(ErrorMessage="Please enter your name")]
        public string Reviewer { get; set; }
        [Required(ErrorMessage = "Please enter your review")]
        public string Comment { get; set; }
        public int MovieIden { get; set; }
        [Display(Name = "Movie")]
        public string MovieTitle { get; set; }
    }
}
