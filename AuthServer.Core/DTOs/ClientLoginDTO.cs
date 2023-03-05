namespace AuthServer.Core.DTOs
{
    public class ClientLoginDTO
    {
        public string CliendId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
    }
}
