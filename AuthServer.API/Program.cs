using AuthServer.Business.Abstract;
using AuthServer.Business.Concrete;
using AuthServer.Business.FluentValidation;
using AuthServer.Core.Configuration;
using AuthServer.Core.Extensions;
using AuthServer.Core.Model;
using AuthServer.DataAccess.Abstract;
using AuthServer.DataAccess.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserSevice, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var dbHost = Environment.GetEnvironmentVariable("dbHost");
var dbName = Environment.GetEnvironmentVariable("dbName");
var dbPassword = Environment.GetEnvironmentVariable("dbPassword");
var dbPort = Environment.GetEnvironmentVariable("dbPort");




builder.Services.AddDbContext<AuthDbContext>(options =>
{
    var connectionString = $"server={dbHost};port={dbPort};database={dbName};User Id=root;password={dbPassword};";

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<AuthDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));

builder.Services.Configure<List<Client>>(builder.Configuration.GetSection("Clients"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience[0],
        IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDTOValidator>();

//fluent Validtation hatalarýný kendi formatýmýzda döndürmek için kod
builder.Services.UserCustomValidationResponse();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cors = Environment.GetEnvironmentVariable("cors").Split(";");

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins(cors)
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseCustomException();
}
//iptal edilebilir
app.UseCustomException();
app.UseCors("corsapp");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
