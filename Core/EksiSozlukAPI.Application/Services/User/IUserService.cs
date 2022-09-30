using EksiSozlukAPI.Application.Features.Commands.User.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Services.User
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse> AddUserAsync(CreateUserCommandRequest createUser);

    }
}
