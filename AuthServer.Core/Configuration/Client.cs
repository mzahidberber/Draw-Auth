namespace AuthServer.Core.Configuration
{
    public class Client
    {
        public string Id { get; set; } = null!;
        public string Secret { get; set; } = null!;
        public List<string> Audiences { get; set; } = null!;
    }
}
