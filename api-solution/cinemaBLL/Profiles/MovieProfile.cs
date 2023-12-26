using AutoMapper;
using Entites.DataTransferObject.MovieDtos;
using Entites.Models;

namespace cinemaBLL.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<MovieForCreateDto, Movie>();
            CreateMap<MovieForUpdateDto, Movie>();
        }
    }
}
