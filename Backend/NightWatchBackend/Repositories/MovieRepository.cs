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

        internal async Task DeleteMovie(int movieid)
        {
            Movie l = await context.Movies.FirstOrDefaultAsync(x => x.MovieId == movieid);
            context.Remove(l);
            await context.SaveChangesAsync();
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

        internal async Task ModifyMovie(int movieId, string title, string length, int ageRating, DateOnly relased, string filePath, string tumbnailPath, string description)
        {
            Movie m = await context.Movies.FirstOrDefaultAsync(x => x.MovieId == movieId);
            m.Title = title;
            m.Length = TimeOnly.Parse(length); 
            m.AgeRating = ageRating;
            m.RelasedOn = relased;
            m.FilePath = filePath;
            m.ThumbnailPath = tumbnailPath;
            m.Description = description;
            await context.SaveChangesAsync();
        }
    }
}
