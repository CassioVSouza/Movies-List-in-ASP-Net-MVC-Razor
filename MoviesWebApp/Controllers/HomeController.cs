using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using MoviesWebApp.Filters;
using MoviesWebApp.Helper;
using MoviesWebApp.Models;
using MoviesWebApp.Repository;
using System.Diagnostics;

namespace MoviesWebApp.Controllers
{
    [PageForLoggedUsers]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieRepository _movieRepository;
        private readonly ISessionUser _sessionUser;

        public HomeController(ILogger<HomeController> logger, IMovieRepository movieRepository,
            ISessionUser sessionUser)
        {
            _logger = logger;
            _movieRepository = movieRepository;
            _sessionUser = sessionUser;
        }

        public IActionResult Index(MovieModel movieModel)
        {
            List<MovieModel> Movies = _movieRepository.GetAllMovies();
            List<MovieModel> userMovies = new List<MovieModel>();
            UserModel user = _sessionUser.FindSession();
            foreach (var movie in Movies) 
            {
                if(movie.UserForeignID == user.Id)
                {
                    userMovies.Add(movie);
                }
            }
            return View(userMovies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
