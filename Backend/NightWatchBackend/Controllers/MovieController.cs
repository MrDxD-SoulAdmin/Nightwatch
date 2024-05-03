using Microsoft.AspNetCore.Mvc;
using NightWatchBackend.Database.Models;
using NightWatchBackend.Repositories;
using NightWatchBackend.Resources;
using NightWatchBackend.Services;

namespace NightWatchBackend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService movieService;

        public MovieController(MovieService movieService) {
            this.movieService = movieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            List<MovieResources> m = await movieService.GetAllMovies();
            return Ok(m);
        }
        [HttpGet]
        public async Task<IActionResult> GetNewMovies()
        {
            List<MovieResources> movie = await movieService.GetNewMovies();
            return Ok(movie);
        }
        [HttpGet]
        public async Task<IActionResult> GetMoviesWhereGenre([FromQuery]string genre)
        {
            List<MovieResources> movie = await movieService.GetMoviesWhereGenre(genre);
            return Ok(movie);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMoviesWhereGenre([FromQuery] string genre)
        {
            List<MovieResources> movie = await movieService.GetAllMoviesWhereGenre(genre);
            return Ok(movie);
        }
        [HttpDelete]
        [Route("/movie/DeleteMovie/{movieid}")]
        public async Task<IActionResult> DeleteMovie(int movieid)
        {
            await movieService.DeleteMovie(movieid);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> ModifyMovie(int movieId,string title, string length, int ageRating, DateOnly relased, string filePath, string tumbnailPath, string description)
        {
            await movieService.ModifyMovie(movieId, title, length, ageRating, relased, filePath, tumbnailPath, description);
            return Ok();
        }
    }
}
