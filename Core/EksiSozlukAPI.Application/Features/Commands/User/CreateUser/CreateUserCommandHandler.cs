using EksiSozlukAPI.Application.Services;
using MediatR;

namespace EksiSozlukAPI.Application.Features.Commands.User.CreateUser
{

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _userService.AddUserAsync(request);
        }
    }
}
