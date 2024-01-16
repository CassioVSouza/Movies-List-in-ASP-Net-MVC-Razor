using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoviesWebApp.Models;
using MoviesWebApp.Repository;

namespace MoviesWebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserRepository _userRepository;
        public RegisterController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.AddUser(userModel);
                    TempData["MessageSucess"] = "Register sucessfully!";
                    return RedirectToAction("Index", "Home");
                }

                return View("Index", userModel);
            }catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
