using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Models;
using MoviesWebApp.Repository;
using System.Diagnostics;

namespace MoviesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieRepository _movieRepository;

        public HomeController(ILogger<HomeController> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        public IActionResult Index(MovieModel movieModel)
        {
            List<MovieModel> Movies = _movieRepository.GetAllMovies();
            return View(Movies);
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
