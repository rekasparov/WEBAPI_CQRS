using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NSI.Service.JwtTokenService.Abstract;
using NSI.Service.JwtTokenService.Concrete;
using NSI.WebApi.Middlewares;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace NSI.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configurationSection = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtSettings");

            // Add services to the container.

            builder.Services.AddTransient<IBaseJwtTokenService, BaseJwtTokenService>();

            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.DefaultBufferSize = 4096;
                x.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configurationSection["Issuer"],
                    ValidAudience = configurationSection["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationSection["Secret"]!))
                };
            });

            builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseExceptionMiddleware();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
