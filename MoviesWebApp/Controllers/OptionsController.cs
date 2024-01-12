using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Models;
using MoviesWebApp.Repository;

namespace MoviesWebApp.Controllers
{
    public class OptionsController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        
        public OptionsController(IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }
        public IActionResult AddMovieMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovieFunction(MovieModel movieModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _movieRepository.AddMovie(movieModel);
                    TempData["MessageSucess"] = "Movie added to your list!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("AddMovieMenu", movieModel);
                }
            }
            catch(Exception ex)
            {
                TempData["MessageError"] = $"The Movie wasn't added to your list! Detailed error: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult EditMenu(int id) 
        {
            MovieModel Movie = _movieRepository.GetMovieById(id);
            return View(Movie);
        }
        [HttpPost]
        public IActionResult EditFunction(MovieModel movieModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _movieRepository.UpdateMovie(movieModel);
                    TempData["MessageSucess"] = "Movie edited in your list!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("EditMenu", movieModel);
                }
            }catch(Exception ex)
            {
                TempData["MessageError"] = $"Movie wasn't edited in your list! Detailed error: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteMenu(int id)
        {
            MovieModel Movie = _movieRepository.GetMovieById(id);
            return View(Movie);
        }

        public IActionResult DeleteFunction(int Id)
        {
            try
            {
                bool Deleted = _movieRepository.DeleteMovie(Id);
                if (Deleted)
                {
                    TempData["MessageSucess"] = "Movie deleted in your list!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MessageError"] = "The movie was not deleted!";
                    return RedirectToAction("DeleteMenu");
                }
            }catch (Exception ex)
            {
                TempData["MessageError"] = $"The movie was not deleted! Detailed error: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
