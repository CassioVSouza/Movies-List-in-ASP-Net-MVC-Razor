using MoviesWebApp.Models;

namespace MoviesWebApp.Repository
{
    public interface IMovieRepository
    {
        public MovieModel AddMovie(MovieModel movieModel);
        public List<MovieModel> GetAllMovies();
        public MovieModel GetMovieById(int id);
        public MovieModel UpdateMovie(MovieModel movieModel);
        public bool DeleteMovie(int id);
    }
}
