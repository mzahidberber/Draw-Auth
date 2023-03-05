using AuthServer.Core.DTOs;

namespace AuthServer.Business.Abstract
{
    public interface IUserSevice
    {
        Task<Response<UserDTO>> CreateUserAsync(CreateUserDTO createUserDTO);
        Task<Response<UserDTO>> GetUserByNameAsync(string username);
    }
}
