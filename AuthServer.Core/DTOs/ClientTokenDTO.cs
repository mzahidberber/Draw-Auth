namespace AuthServer.Core.DTOs
{
    public class ClientTokenDTO
    {
        public string AccessToken { get; set; } = null!;
        public DateTime AccessTokenExpiration { get; set; }
    }
}
