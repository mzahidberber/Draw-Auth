using AuthServer.Core.DTOs;

namespace AuthServer.Business.Abstract
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDTO>> CreateTokenAsync(LoginDTO loginDto);
        Task<Response<TokenDTO>> CreateTokenByRefreshTokenAsync(string refreshToken);
        Task<Response<NoDataDTO>> RevokeRefreshTokenAsync(string refreshToken);
        Response<ClientTokenDTO> CreateTokenByClient(ClientLoginDTO clientLoginDto);
    }
}
