using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Movies.Api.Docker;
using Movies.Api.Docker.EndpointMapper;
using Movies.Api.Docker.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddCustomDbContext(builder.Configuration)
    .RegisterCustomServices()
    .AddHealthChecks()
    .AddPostgreSQLHealthCheck(builder.Configuration);

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();
if(app.Environment.IsDevelopment())
{
    app.ApplyMigration(logger);
    app.UseDeveloperExceptionPage();
}
app.MapMovieEndpoints();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
