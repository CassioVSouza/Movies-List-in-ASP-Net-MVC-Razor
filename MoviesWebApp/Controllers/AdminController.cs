using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Filters;
using MoviesWebApp.Helper;
using MoviesWebApp.Models;
using MoviesWebApp.Repository;

namespace MoviesWebApp.Controllers
{
    [PageForLoggedUsers]
    [PageForAdmin]
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionUser _sessionUser;
        public AdminController(IUserRepository userRepository, ISessionUser sessionUser) 
        {
            _userRepository = userRepository;
            _sessionUser = sessionUser;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAllUsers();
            return View(users);
        }
    }
}
