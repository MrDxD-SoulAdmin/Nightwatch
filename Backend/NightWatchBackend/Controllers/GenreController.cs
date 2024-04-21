using Microsoft.AspNetCore.Mvc;
using NightWatchBackend.Database.Models;
using NightWatchBackend.Resources;
using NightWatchBackend.Services;

namespace NightWatchBackend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenreController : Controller
    {
        private readonly GenreService genreService;

        public GenreController(GenreService genreService) {
            this.genreService = genreService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGenre()
        {
            List<GenreResources> g = await genreService.GetAllGenre();
            return Ok(g);
        }
    }
}
