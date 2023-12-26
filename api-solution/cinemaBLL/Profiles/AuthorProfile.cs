using AutoMapper;
using Entites.DataTransferObject.AuthorDtos;
using Entites.Models;

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
