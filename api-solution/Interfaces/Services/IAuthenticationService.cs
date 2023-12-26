using Entites.DataTransferObject.UserDtos;
using Entites.Jwt;
using Microsoft.AspNetCore.Identity;

namespace Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto);
        Task<JwtToken?> AuthenticateUserAsync(UserForLoginDto userForLoginDto);
    }
}
