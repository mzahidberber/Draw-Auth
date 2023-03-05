using AuthServer.Business.Abstract;
using AuthServer.Core.DTOs;
using AuthServer.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace AuthServer.Business.Concrete
{
    public class UserService : IUserSevice
    {
        private UserManager<User> _userManager;
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;   
        }
        public async Task<Response<UserDTO>> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var user=new User { Email=createUserDTO.Email,UserName=createUserDTO.UserName};
            var result=await _userManager.CreateAsync(user,createUserDTO.Password);
            if(!result.Succeeded)
            {
                var errors=result.Errors.Select(x=>x.Description).ToList();
                return Response<UserDTO>.Fail(new ErrorDTO(errors, true), 400);
            }
            return Response<UserDTO>.Success(ObjectMapper.Mapper.Map<UserDTO>(user),200);
        }

        public async Task<Response<UserDTO>> GetUserByNameAsync(string username)
        {
            var user=await _userManager.FindByNameAsync(username);
            if(user==null)
            {
                return Response<UserDTO>.Fail("Username not found", 400,true);
            }
            return Response<UserDTO>.Success(ObjectMapper.Mapper.Map<UserDTO>(user), 200);
        }
    }
}
