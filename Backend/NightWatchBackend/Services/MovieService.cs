using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

        internal async Task DeleteMovie(int movieid)
        {
            await movieRepository.DeleteMovie(movieid);
      
        }

        internal async Task<List<MovieResources>> GetAllMovies()
        {
            List<Movie> m = await movieRepository.GetAllMovies();
            return mapper.Map<List<MovieResources>>(m);
        }

        internal async Task<List<MovieResources>> GetAllMoviesWhereGenre(string genre)
        {
            List<Movie> m = await movieRepository.GetAllMoviesWhereGenre(genre);
            return mapper.Map<List<MovieResources>>(m);
        }

        internal async Task<List<MovieResources>> GetMoviesWhereGenre(string genre)
        {
            List<Movie> m = await movieRepository.GetMoviesWhereGenre(genre);
            return mapper.Map<List<MovieResources>>(m);
        }

        internal async Task<List<MovieResources>> GetNewMovies()
        {
            List<Movie> m = await movieRepository.GetNewMovies();
            return mapper.Map<List<MovieResources>>(m);
        }

        internal async Task ModifyMovie(int movieId, string title, string length, int ageRating, DateOnly relased, string filePath, string tumbnailPath, string description)
        {
            await movieRepository.ModifyMovie(movieId, title, length, ageRating, relased, filePath, tumbnailPath, description);
        }
    }
}
