using AutoMapper;
using NightWatchBackend.Database.Models;
using NightWatchBackend.Repositories;
using NightWatchBackend.Resources;

namespace NightWatchBackend.Services
{
    public class MovieService
    {
        private readonly MovieRepository movieRepository;
        private readonly IMapper mapper;

        public MovieService(MovieRepository movieRepository,IMapper mapper) {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

        internal async Task<List<MovieResources>> GetAllMovies()
        {
            List<Movie> m = await movieRepository.GetAllMovies();
            return mapper.Map<List<MovieResources>>(m);
        }
    }
}
