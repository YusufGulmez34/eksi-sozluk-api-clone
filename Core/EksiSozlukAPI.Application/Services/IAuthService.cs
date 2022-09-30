using EksiSozlukAPI.Application.DTOs;
using EksiSozlukAPI.Application.Features.Commands.User.LoginUser;
using System.Security.Claims;

namespace EksiSozlukAPI.Application.Services
{
    public interface IAuthService
    {
        Token CreateToken(List<Claim> claimList);
        Task<Token> UserLogin(LoginUserCommandRequest loginUser);
        
    }
}
