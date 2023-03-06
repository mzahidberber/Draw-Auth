using AuthServer.Business.Abstract;
using AuthServer.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AuthController
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("createtoken")]
        public async Task<Response<TokenDTO>> CreateToken(LoginDTO loginDto)
        {
            return await _authenticationService.CreateTokenAsync(loginDto);
        }

        [HttpPost("createtokenbyclient")]
        public Response<ClientTokenDTO> CreateTokenByClient(ClientLoginDTO clientLoginDto)
        {
            return _authenticationService.CreateTokenByClient(clientLoginDto);
        }

        [HttpPost("revokerefreshtoken")]
        public async Task<Response<NoDataDTO>> RevokeRefreshToken(RefreshTokenDTO refreshToken)
        {
            return await _authenticationService.RevokeRefreshTokenAsync(refreshToken.Token);
        }

        [HttpPost("createtokenbyrefreshtoken")]
        public async Task<Response<TokenDTO>> CreateTokenByRefreshToken(RefreshTokenDTO refreshTokenDto)
        {
            return await _authenticationService.CreateTokenByRefreshTokenAsync(refreshTokenDto.Token);
        }
    }
}