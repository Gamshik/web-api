using AutoMapper;
using Entites;
using Entites.DataTransferObject;

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
