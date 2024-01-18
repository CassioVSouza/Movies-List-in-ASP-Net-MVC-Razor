using MoviesWebApp.Models;

namespace MoviesWebApp.Repository
{
    public interface IUserRepository
    {
        public UserModel AddUser(UserModel userModel);
        public UserModel GetUserByLogin(string Login);
        public List<UserModel> GetAllUsers();
    }
}
