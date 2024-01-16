using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }
        public UserModel AddUser(UserModel userModel)
        {
            _databaseContext.Users.Add(userModel);
            _databaseContext.SaveChanges();
            return userModel;
        }

        public UserModel GetUserByLogin(string Login)
        {
            return _databaseContext.Users.FirstOrDefault(x => x.LoginUser.ToUpper() == Login.ToUpper());
        }

    }
}
