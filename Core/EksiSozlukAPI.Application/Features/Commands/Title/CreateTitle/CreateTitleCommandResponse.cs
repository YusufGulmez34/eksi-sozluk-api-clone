using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle
{
    public class CreateTitleCommandResponse : Response
    {
        public CreateTitleCommandResponse(bool success, string message) : base(success, message)
        {
        }
    }
    public class SuccessCreateTitleCommandResponse : CreateTitleCommandResponse
    {
        public SuccessCreateTitleCommandResponse(string message) : base(true, message)
        {
        }
    }

    public class ErrorCreateTitleCommandResponse : CreateTitleCommandResponse
    {
        public ErrorCreateTitleCommandResponse(string message) : base(false, message)
        {
        }
    }
}
