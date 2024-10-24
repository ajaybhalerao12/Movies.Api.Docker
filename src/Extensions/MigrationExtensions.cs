using Microsoft.EntityFrameworkCore;
using Movies.Api.Docker.Database;

namespace Movies.Api.Docker.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigration(this IApplicationBuilder app, ILogger logger)
        {
            try
            {
                using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

                using ApplicationDbContext applicationDbContext = serviceScope.ServiceProvider
                    .GetRequiredService<ApplicationDbContext>();

                applicationDbContext.Database.Migrate();

                logger.LogInformation("Database migration ran successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while applying migrations");
            }
        }
    }
}
