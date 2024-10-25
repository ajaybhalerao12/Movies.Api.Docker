using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movies.Api.Docker.Database;
using Movies.Api.Docker.Services;

namespace Movies.Api.Docker
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {            
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IRedisCacheService, RedisCacheService>();
            services.AddAutoMapper(typeof(Program));
            return services;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movies API",
                    Description = "An API for managing movies"
                });
            });
            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        
        public static IHealthChecksBuilder AddPostgreSQLHealthCheck(this IHealthChecksBuilder services, IConfiguration configuration)
        {
            services.AddNpgSql(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }
    }
}
