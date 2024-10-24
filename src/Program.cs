using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Docker.Database;
using Movies.Api.Docker.Dtos;
using Movies.Api.Docker.Entities;
using Movies.Api.Docker.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/movies/{id}",async (Guid id,
    IMovieService movieService, CancellationToken cancellationToken) =>
{
    var movie = await movieService.
    GetMovieByIdAsync(id, cancellationToken);
    if (movie == null)
    {
        return Results.NotFound($"Movie with id {id} not found");
    }
    return Results.Ok(movie);
}).WithName("GetMovieById");

app.MapPost("/api/movies", async ([FromBody]MovieDto movieDto,
    IMovieService movieService,CancellationToken cancellationToken) =>
{
    var movie = await movieService.AddMovieAsync(movieDto, cancellationToken);
    return Results.CreatedAtRoute("GetMovieById",
        new { movie.Id },
        movie);
}).WithName("CreateMovie");

app.Run();
