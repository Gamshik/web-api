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
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<AuthorForCreateDto, Author>();
            CreateMap<AuthorForUpdateDto, Author>();
        }
    }
}
