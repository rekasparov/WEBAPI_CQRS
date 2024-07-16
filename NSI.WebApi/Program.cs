using FluentValidation;
using NSI.DataTransferObject;
using NSI.Validation;
using System.Reflection;
using System.Text.Json.Serialization;

namespace NSI.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.DefaultBufferSize = 4096;
                x.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            builder.Services.AddScoped<IValidator<DepartmentDTO>, DepartmentValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
