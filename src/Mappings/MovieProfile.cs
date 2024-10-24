using AutoMapper;
using Movies.Api.Docker.Dtos;
using Movies.Api.Docker.Entities;

namespace Movies.Api.Docker.Mappers
{
    public class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie,MovieDto>();
        }
    }
}
