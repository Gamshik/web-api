using AutoMapper;
using Entites.DataTransferObject.UserDtos;
using Entites.Jwt;
using Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace cinemaBLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSetting;
        private IdentityUser? _identityUser;
        public AuthenticationService(IMapper mapper, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _jwtSetting = _configuration.GetSection("JwtSettings");
        }
        public async Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<IdentityUser>(userForRegistrationDto);
            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            return result;
        }
        public async Task<JwtToken?> AuthenticateUserAsync(UserForLoginDto userForLoginDto)
        {
            _identityUser = await _userManager.FindByNameAsync(userForLoginDto.Name);

            if (_identityUser != null && await _userManager.CheckPasswordAsync(_identityUser, userForLoginDto.Password))
            {
                return new JwtToken { Token = GenerateToken() };
            }

            return null;
        }
        private string GenerateToken()
        {
            var signingCredential = GetSigningCredentials();
            var claims = GetClaimsAsync();
            var tokenOptions = SetTokenOptions(signingCredential, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSetting.GetSection("securityKey").Value);

            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private List<Claim> GetClaimsAsync()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _identityUser.UserName)
            };
            return claims;
        }
        private JwtSecurityToken SetTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSetting.GetSection("validIssuer").Value,
                audience: _jwtSetting.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSetting.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials
                );
            return tokenOptions;
        }
    }
}