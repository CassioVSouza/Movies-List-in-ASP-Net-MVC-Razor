using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Models;

namespace MoviesWebApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) 
        {

        }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
