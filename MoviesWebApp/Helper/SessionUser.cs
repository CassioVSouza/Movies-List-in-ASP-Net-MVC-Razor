using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Models;
using System.Text.Json;

namespace MoviesWebApp.Helper
{
    public class SessionUser : ISessionUser
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMyLogger _myLogger;
        public SessionUser(IHttpContextAccessor httpContextAccessor, IMyLogger myLogger)
        {
            _contextAccessor = httpContextAccessor;
            _myLogger = myLogger;
        }
        public void CreateSession(UserModel userModel)
        {
            string userSerialized = JsonSerializer.Serialize(userModel);
            _contextAccessor.HttpContext.Session.SetString("UserLogin", userSerialized);
        }

        public UserModel FindSession()
        {
            string sessionUser = _contextAccessor.HttpContext.Session.GetString("UserLogin");

            if (string.IsNullOrEmpty(sessionUser)) return null;

            return JsonSerializer.Deserialize<UserModel>(sessionUser);
        }

        public void RemoveSession()
        {
            try
            {
                if (_contextAccessor?.HttpContext?.Session != null)
                {
                    _contextAccessor.HttpContext.Session.Remove("UserLogin");
                }
            }
            catch (Exception ex)
            {
                _myLogger.MessageToLog(ex.Message);
            }
        }
    }
}
