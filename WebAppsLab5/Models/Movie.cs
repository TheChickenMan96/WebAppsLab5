using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppsLab5.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter a movie title that is at least 3 character long")]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please enter the appropriate release date for this movie")]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required(ErrorMessage = "Please enter a genre for this movie")]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please enter the price for this movie")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select a rating for this movie")]
        public string Rating { get; set; }
    }
}
