﻿using MoviesWebApp.Models;

namespace MoviesWebApp.Helper
{
    public interface ISessionUser
    {
        void CreateSession(UserModel userModel);
        void RemoveSession();
        UserModel FindSession();
    }
}
