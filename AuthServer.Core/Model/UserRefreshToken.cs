﻿namespace AuthServer.Core.Model
{
    public class UserRefreshToken
    {
        public string UserId { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}
