using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DatabaseContext _databaseContext;
        public MovieRepository(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }

        public MovieModel AddMovie(MovieModel movieModel)
        {
            _databaseContext.Movies.Add(movieModel);
            _databaseContext.SaveChanges();
            return movieModel;
        }

        public bool DeleteMovie(int id)
        {
            MovieModel MovieDB = GetMovieById(id);

            _databaseContext.Movies.Remove(MovieDB);
            _databaseContext.SaveChanges();
            return true;
        }

        public List<MovieModel> GetAllMovies()
        {
            List<MovieModel> Movies = _databaseContext.Movies.ToList();
            return Movies;
        }

        public MovieModel GetMovieById(int id)
        {
            MovieModel Movie = _databaseContext.Movies.FirstOrDefault(x => x.Id == id);
            return Movie;
        }

        public MovieModel UpdateMovie(MovieModel movieModel)
        {
            MovieModel MovieDB = GetMovieById(movieModel.Id);

            MovieDB.Title = movieModel.Title;
            MovieDB.Genre = movieModel.Genre;
            MovieDB.ReleaseYear = movieModel.ReleaseYear;
            _databaseContext.Movies.Update(MovieDB);
            _databaseContext.SaveChanges();
            return MovieDB;
        }
    }
}
