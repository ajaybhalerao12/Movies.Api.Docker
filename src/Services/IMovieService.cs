using Movies.Api.Docker.Dtos;
using Movies.Api.Docker.Entities;

namespace Movies.Api.Docker.Services
{
    public interface IMovieService
    {
        Task<Movie> AddMovieAsync(MovieDto movie, CancellationToken cancellationToken);
        Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
