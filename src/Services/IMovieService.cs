using Movies.Api.Docker.Dtos;
using Movies.Api.Docker.Entities;

namespace Movies.Api.Docker.Services
{
    public interface IMovieService
    {
        Task<Movie> AddMovieAsync(MovieDto movie, CancellationToken cancellationToken);
        Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Movie>> GetAllMoviesAsync(CancellationToken cancellationToken);
        Task DeleteMovieAsync(Guid id, CancellationToken cancellationToken);
        Task<Movie> UpdateMovieAsync(Guid id, MovieDto movie, CancellationToken cancellationToken);
    }
}
