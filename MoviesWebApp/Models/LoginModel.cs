using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Write your login!")]
        public string Login { get; set; } = null!;
        [Required(ErrorMessage = "Write your password!")]
        public string Password { get; set; } = null!;
    }
}
