using Microsoft.AspNetCore.Mvc;
using NightWatchBackend.Communication;
using NightWatchBackend.Database.Models;
using NightWatchBackend.Resources;
using NightWatchBackend.Services;

namespace NightWatchBackend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService) {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(){
           List<UserResources> u = await userService.GetAllUsers();
            return Ok(u);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginData data)
        {
            User Usr = await userService.UsrLogin(data);
            if (Usr == null)
            {
                return Ok(new { message="Hiba!" });
            }
            else
            {
                return Ok(Usr);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegData data)
        {
            User usr = await userService.UserReg(data);
            return Ok(usr);
        }
    }
}
