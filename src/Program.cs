using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Movies.Api.Docker;
using Movies.Api.Docker.EndpointMapper;
using Movies.Api.Docker.Extensions;
using Movies.Api.Docker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddCustomDbContext(builder.Configuration)
    .AddSwaggerServices()
    .RegisterCustomServices()
    .AddHealthChecks()
    .AddPostgreSQLHealthCheck(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisCache");
    options.InstanceName = "Movies.Api.Docker";
});
builder.Services.AddHealthChecks()
    .AddRedis(builder.Configuration.GetConnectionString("RedisCache"));

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();
if(app.Environment.IsDevelopment())
{
    app.ApplyMigration(logger);
    app.RegisterMiddlewares();
}

app.UseHttpsRedirection();
app.MapMovieEndpoints();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
