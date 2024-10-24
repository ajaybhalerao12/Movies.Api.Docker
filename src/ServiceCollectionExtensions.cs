using Microsoft.EntityFrameworkCore;
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
