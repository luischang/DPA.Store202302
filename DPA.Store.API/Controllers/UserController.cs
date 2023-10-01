using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace DPA.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> 
            SignUp([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var result= await _userService.SignUp(userRegisterDTO);
            if (!result)
                return BadRequest();

            return Ok(result);
        }


    }
}
