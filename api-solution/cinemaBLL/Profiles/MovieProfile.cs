using AutoMapper;
using Entites;
using Entites.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
