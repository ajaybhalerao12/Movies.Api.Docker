using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Docker.Database;
using Movies.Api.Docker.Dtos;
using Movies.Api.Docker.Entities;

namespace Movies.Api.Docker.Services
{
    public class MovieService(ApplicationDbContext context,
        IMapper mapper) : IMovieService
    {      
        public async Task<Movie> AddMovieAsync(MovieDto movieDto, CancellationToken cancellationToken)
        {
            //Map Movie
            var movie = mapper.Map<Movie>(movieDto);
            movie.Id = Guid.NewGuid();

            context.Movies.Add(movie);
            await context.SaveChangesAsync(cancellationToken);
            return movie;
        }

        public async Task DeleteMovieAsync(Guid id, CancellationToken cancellationToken)
        {
            //Movie? movie = await context.Movies.FindAsync(id);
           var movie = await context.Movies.FirstOrDefaultAsync
                (x => x.Id == id, cancellationToken) ?? throw new Exception($"Movie not found with id {id}");
            context.Movies.Remove(movie);
            await context.SaveChangesAsync(cancellationToken);
            return;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync(CancellationToken cancellationToken)
        {
            return await context.Movies
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var movie = await context.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return movie;
        }

        public async Task<Movie> UpdateMovieAsync(Guid id, MovieDto movieDto, CancellationToken cancellationToken)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (movie == null)
            {
                throw new Exception($"Movie not found with id {id}");
            }

            // Update movie properties
            movie.Title = movieDto.Title;
            movie.Genre = movieDto.Genre;
            movie.ReleaseDate = DateTime.SpecifyKind(movieDto.ReleaseDate, DateTimeKind.Utc); // Ensure UTC
            movie.Director = movieDto.Director;
            movie.Rating = movieDto.Rating;
            movie.Synopsis = movieDto.Synopsis;

            await context.SaveChangesAsync(cancellationToken);
            return movie;
        }
    }
}
