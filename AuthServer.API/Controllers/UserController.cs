using AuthServer.Business.Abstract;
using AuthServer.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private IUserSevice _userService;
        public UserController(IUserSevice userService)
        {
            _userService = userService;
        }
        [HttpPost("createuser")]
        public async Task<Response<UserDTO>> CreateUser(CreateUserDTO createUserDto)
        {
            //throw new CustomException("veri tabanı ile ilgli bir hata meydana geldi");
            return await _userService.CreateUserAsync(createUserDto);
        }
        [Authorize]
        [HttpGet("getuser")]
        public async Task<Response<UserDTO>> GetUser()
        {
            if(HttpContext.User.Identity!=null &&  HttpContext.User.Identity.Name!=null)
            {
                return await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);
            }
            else
            {
                return new Response<UserDTO>();
            }
            
        }



    }
}
