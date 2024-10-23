using Microsoft.EntityFrameworkCore;
using Movies.Api.Docker.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
