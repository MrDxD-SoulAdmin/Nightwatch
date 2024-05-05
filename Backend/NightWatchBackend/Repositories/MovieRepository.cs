using Microsoft.EntityFrameworkCore;
using NightWatchBackend.Communication;
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

        internal async Task DeleteMovie(int movieid)
        {
            Movie l = await context.Movies.FirstOrDefaultAsync(x => x.MovieId == movieid);
            context.Remove(l);
            await context.SaveChangesAsync();
        }

        internal async Task<Movie> GetMovieByID(int id)
        {
            Movie l = await context.Movies.FirstOrDefaultAsync(x => x.MovieId == id);
            return l;
        }

        internal async Task<List<Movie>> GetAllMovies()
        {
            return await context.Movies.ToListAsync();
        }

        internal async Task<List<Movie>> GetAllMoviesWhereGenre(string genre)
        {
            return await context.Movies.Where(x => x.Genres.Any(y => y.GenreName == genre)).ToListAsync();
        }

        internal async Task<List<Movie>> GetMoviesWhereGenre( string genre)
        {
            return await context.Movies.Where(x => x.Genres.Any( y => y.GenreName == genre)).Take(7).ToListAsync();
        }

        internal async Task<List<Movie>> GetNewMovies()
        {
            return await context.Movies.OrderByDescending(x => x.RelasedOn).Take(7).ToListAsync();
        }

        internal async Task ModifyMovie()
        {
           await context.SaveChangesAsync();
        }
    }
}
