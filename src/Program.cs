using Movies.Api.Docker;
using Movies.Api.Docker.EndpointMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddCustomDbContext(builder.Configuration)
    .RegisterCustomServices();


var app = builder.Build();
app.MapMovieEndpoints();

app.Run();
