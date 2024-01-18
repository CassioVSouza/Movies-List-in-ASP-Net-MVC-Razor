using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Helper;
using MoviesWebApp.Models;
using MoviesWebApp.Repository;

namespace MoviesWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionUser _sessionUser;
        public LoginController(IUserRepository userRepository, ISessionUser sessionUser) 
        {
            _userRepository = userRepository;
            _sessionUser = sessionUser;
        }
        public IActionResult Index()
        {
            if(_sessionUser.FindSession() != null) 
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult LoginUser(LoginModel loginModel)
        {
            try
            {
               if(ModelState.IsValid)
                {
                    UserModel user = _userRepository.GetUserByLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (user.CheckPassword(loginModel.Password))
                        {
                            _sessionUser.CreateSession(user);
                            TempData["MessageSucess"] = "Login sucessfully!";
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["ErrorMessage"] = "Wrong Password!";
                        return View("Index", loginModel);
                    }
                    TempData["ErrorMessage"] = "This user doesn't exist!";
                    return View("Index", loginModel);
                }
                return View("Index", loginModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ExitAccount()
        {
            _sessionUser.RemoveSession();
            return View("Index");
        }
    }
}
