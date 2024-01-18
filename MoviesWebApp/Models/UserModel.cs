using MoviesWebApp.Enums;
using MoviesWebApp.Repository;
using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Models
{
    public class UserModel
    {
        public UserModel() 
        {
            Profile = ProfileEnum.Normal;

        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Write your name!")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Write your email!")]
        [EmailAddress(ErrorMessage = "Write a valid email!")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Write your password!")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Write your user!")]
        public string LoginUser { get; set; } = null!;
        public ProfileEnum Profile { get; set; }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }
    }
}
