using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandResponse : Response
    {
        public CreateUserCommandResponse(bool success, string message) : base(success, message)
        {
        }
    }

    public class SuccessCreateUserCommandResponse : CreateUserCommandResponse
    {
        public SuccessCreateUserCommandResponse(string message) : base(true, message)
        {
        }
    }

    public class ErrorCreateUserCommandResponse : CreateUserCommandResponse
    {
        public ErrorCreateUserCommandResponse(string message) : base(false, message)
        {
        }
    }
}
