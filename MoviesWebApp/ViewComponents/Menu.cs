using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Models;
using System.Text.Json;

namespace MoviesWebApp.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("UserLogin");

            if (string.IsNullOrEmpty(userSession)) return null;
            
            UserModel user = JsonSerializer.Deserialize<UserModel>(userSession);

            return View(user);
        }
    }
}
