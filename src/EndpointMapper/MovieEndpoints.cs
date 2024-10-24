using Movies.Api.Docker.Dtos;
using Movies.Api.Docker.Services;

namespace Movies.Api.Docker.EndpointMapper
{
    public static class MovieEndpoints
    {
        public static void MapMovieEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", () => "Hello World!");

            var movieGroup = app.MapGroup("/api/movies");
            movieGroup.MapGet("{id}", GetBookByIdAsync).WithName("GetMovieById");
            movieGroup.MapPost("", AddMovieAsync).WithName("CreateMovie");
            //app.MapPost("/api/movies", AddMovieAsync()).WithName("CreateMovie");
            //app.MapGet("/api/movies/{id}", GetBookByIdAsync()).WithName("GetMovieById");
        }

        private static async Task<IResult> AddMovieAsync(MovieDto movieDto,
                IMovieService movieService, CancellationToken cancellationToken)
        {
            var movie = await movieService.AddMovieAsync(movieDto, cancellationToken);
            return Results.CreatedAtRoute("GetMovieById",
                new { movie.Id },
                movie);
        }

        private static async Task<IResult> GetBookByIdAsync(Guid id,
                IMovieService movieService,
                CancellationToken cancellationToken)
        {
            var movie = await movieService.
                GetMovieByIdAsync(id, cancellationToken);
            if (movie == null)
            {
                return Results.NotFound($"Movie with id {id} not found");
            }
            return Results.Ok(movie);
        }
    }
}
