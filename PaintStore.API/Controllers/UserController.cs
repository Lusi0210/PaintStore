using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.API.DataAccess;
using PaintStore.API.Services;
using PaintStore.Models;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {          
            User newUser = _userService.CreateUser(user);

            return Created("GetUserById",newUser);
        }
    }
}
