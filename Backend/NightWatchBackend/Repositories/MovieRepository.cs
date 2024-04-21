using Microsoft.EntityFrameworkCore;
using NightWatchBackend.Database;
using NightWatchBackend.Database.Models;

namespace NightWatchBackend.Repositories
{
    public class MovieRepository
    {
        private readonly NightWatchDbContext context;

        public MovieRepository(NightWatchDbContext context) {
            this.context = context;
        }

        internal async Task<List<Movie>> GetAllMovies()
        {
            return await context.Movies.ToListAsync();
        }
    }
}
