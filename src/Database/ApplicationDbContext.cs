using Microsoft.EntityFrameworkCore;
using Movies.Api.Docker.Entities;

namespace Movies.Api.Docker.Database
{
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
