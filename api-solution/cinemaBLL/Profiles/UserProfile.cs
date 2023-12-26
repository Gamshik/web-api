using AutoMapper;
using Entites.DataTransferObject.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace cinemaBLL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForRegistrationDto, IdentityUser>();
            CreateMap<UserForLoginDto, IdentityUser>();
        }
    }
}
