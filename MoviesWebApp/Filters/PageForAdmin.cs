using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviesWebApp.Helper;
using MoviesWebApp.Models;
using System.Text.Json;

namespace MoviesWebApp.Filters
{
    public class PageForAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string session = context.HttpContext.Session.GetString("UserLogin");

            UserModel sessionUser = JsonSerializer.Deserialize<UserModel>(session);


            if (sessionUser.Profile != Enums.ProfileEnum.Admin && sessionUser.Profile != Enums.ProfileEnum.Developer)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
            }

            base.OnActionExecuting(context);
        }
    }
}
