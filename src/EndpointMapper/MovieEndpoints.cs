using Movies.Api.Docker.Dtos;
using Movies.Api.Docker.Services;
using Movies.Api.Docker.Entities;

namespace Movies.Api.Docker.EndpointMapper
{
    public static class MovieEndpoints
    {
        public static void MapMovieEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", () => "Hello World!");

            var movieGroup = app.MapGroup("/api/movies");
            movieGroup.MapGet(
                "{id}", GetBookByIdAsync).WithName("GetMovieById");
            movieGroup.MapPost(
                "", AddMovieAsync).WithName("CreateMovie");
            movieGroup.MapGet(
                "", GetAllMoviesAsync).WithName("GetAllMovies");
            movieGroup.MapPut(
                "{id}", UpdateMovieAsync).WithName("UpdateMovie");
            movieGroup.MapDelete(
                "{id}", DeleteMovieAsync).WithName("DeleteMovie");
        }

        private static async Task<IResult> DeleteMovieAsync(Guid id,
            IMovieService movieService,
            CancellationToken cancellationToken)
        {
            await movieService
                .DeleteMovieAsync(id, cancellationToken);
            return Results.Ok();
        }

        private static async Task<IResult> UpdateMovieAsync(Guid id,
            MovieDto movieDto,
            IMovieService movieService,
            CancellationToken cancellationToken)
        {
            var movie = await movieService.UpdateMovieAsync(id, movieDto, cancellationToken);
            return Results.Ok(movie);
        }

        private static async Task<IResult> GetAllMoviesAsync(IMovieService movieService,
            CancellationToken cancellationToken)
        {
            var movies = await movieService.GetAllMoviesAsync(cancellationToken);
            return Results.Ok(movies);
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

        //private static Func<MovieDto, IMovieService, CancellationToken, Task<IResult>> AddMovieAsync()
        //{
        //    return async (MovieDto movieDto,
        //        IMovieService movieService, CancellationToken cancellationToken) =>
        //    {
        //        var movie = await movieService.AddMovieAsync(movieDto, cancellationToken);
        //        return Results.CreatedAtRoute("GetMovieById",
        //            new { movie.Id },
        //            movie);
        //    };
        //}
    }

}
