using AuthServer.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DataAccess.Concrete
{
    public class AuthDbContext:IdentityDbContext<User,IdentityRole,string>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> opt):base(opt) { }
        
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
