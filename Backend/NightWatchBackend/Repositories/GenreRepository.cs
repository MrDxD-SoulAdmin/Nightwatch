using Microsoft.EntityFrameworkCore;
using NightWatchBackend.Database;
using NightWatchBackend.Database.Models;
using NightWatchBackend.Resources;

namespace NightWatchBackend.Repositories
{
    public class GenreRepository
    {
        private readonly NightWatchDbContext context;

        public GenreRepository(NightWatchDbContext context)
        {
            this.context = context;
        }
        internal async Task<List<Genre>> GetAllGenre()
        {
            return await context.Genres.Include(x => x.Movies).ToListAsync();
        }
    }
}
