using EksiSozlukAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandResponse : ResponseData<Token>
    {

        public LoginUserCommandResponse(Token token, bool success, string message) : base(token, success, message)
        {
        }
    }

    public class SuccessLoginUserCommandResponse : LoginUserCommandResponse
    {

        public SuccessLoginUserCommandResponse(Token token, string message) : base(token, true, message)
        {
        }
    }

    public class ErrorLoginUserCommandResponse : LoginUserCommandResponse
    {
        public ErrorLoginUserCommandResponse(string message) : base(null, false, message)
        {
        }
    }
}
