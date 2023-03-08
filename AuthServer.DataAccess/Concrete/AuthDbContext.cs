using AuthServer.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DataAccess.Concrete
{
    public class AuthDbContext:IdentityDbContext<User,IdentityRole,string>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> opt) : base(opt) { }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var cnn = $"server=localhost;port=3306;database=drawdb1;user=root;password=mysql123.;";
        //    optionsBuilder.UseMySql(cnn,ServerVersion.AutoDetect(cnn));
        //}
    }
}
