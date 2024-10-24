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

        public async Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var movie = await context.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return movie;
        }
    }
}
