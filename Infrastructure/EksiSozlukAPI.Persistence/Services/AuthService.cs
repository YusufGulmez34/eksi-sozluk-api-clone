
using EksiSozlukAPI.Application.DTOs;
using EksiSozlukAPI.Application.Features.Commands.User.LoginUser;
using EksiSozlukAPI.Application.Repositories.User;
using EksiSozlukAPI.Application.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserReadRepository _userRepository;

        public AuthService(IUserReadRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public Token CreateToken(List<Claim> claimList)
        {
            Token token = new() { Expiration = DateTime.Now.AddMinutes(15) };

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes("abcdefghjklmiiprstuvyz"));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new(
               audience: "www.xxx.com",
               issuer: "www.xxx.com",
               expires: token.Expiration,
               notBefore: DateTime.UtcNow,
               signingCredentials: signingCredentials,
               claims: claimList);

            token.AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;

        }

        public async Task<Token> UserLogin(LoginUserCommandRequest loginUser)
        {
            E.User user = await _userRepository.FindSingleAsync(u => u.Nickname == loginUser.Nickname);
            if (user == null || user.Password != loginUser.Password) return null;
          
            List<string> userRoles = _userRepository.GetUserRolesById(user.Id);

            List<Claim> claims = new();
            claims.Add(new Claim(ClaimTypes.Name, user.Nickname));
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return CreateToken(claims);
        }


    }
}
