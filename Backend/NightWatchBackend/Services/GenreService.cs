using AutoMapper;
using NightWatchBackend.Database.Models;
using NightWatchBackend.Repositories;
using NightWatchBackend.Resources;

namespace NightWatchBackend.Services
{
    public class GenreService
    {
        private readonly GenreRepository genreRepository;
        private readonly IMapper mapper;

        public GenreService(GenreRepository genreRepository,IMapper mapper) {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }
        internal async Task<List<GenreResources>> GetAllGenre()
        {
            List<Genre> g = await genreRepository.GetAllGenre();
            return mapper.Map<List<GenreResources>>(g);
        }
    }
}
