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
    }
}
