using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Write the title of the movie!")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Write the genre of the movie!")]
        public string Genre { get; set; } = null!;
        [Required(ErrorMessage = "Write the release year of the movie!")]
        public int ReleaseYear { get; set; }
    }
}
