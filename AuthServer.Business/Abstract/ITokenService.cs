using AuthServer.Core.Configuration;
using AuthServer.Core.DTOs;
using AuthServer.Core.Model;

namespace AuthServer.Business.Abstract
{
    public interface ITokenService
    {
        TokenDTO CreateToken(User user);
        ClientTokenDTO CreateClientToken(Client client);
    }
}
