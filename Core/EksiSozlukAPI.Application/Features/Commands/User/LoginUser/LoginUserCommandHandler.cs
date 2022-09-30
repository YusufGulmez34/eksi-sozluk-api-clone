using EksiSozlukAPI.Application.DTOs;
using EksiSozlukAPI.Application.Services;
using MediatR;

namespace EksiSozlukAPI.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await _authService.UserLogin(request);
            if (token == null) return new ErrorLoginUserCommandResponse("Error");
            return new SuccessLoginUserCommandResponse(token,"Error");
        }
    }
}
