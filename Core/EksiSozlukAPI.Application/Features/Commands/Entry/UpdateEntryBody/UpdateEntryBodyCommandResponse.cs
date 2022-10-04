using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.Entry.UpdateEntryBody
{
    public class UpdateEntryBodyCommandResponse : Response
    {
        public UpdateEntryBodyCommandResponse(bool success, string message) : base(success, message)
        {
        }
    }

    public class SuccessUpdateEntryBodyCommandResponse : UpdateEntryBodyCommandResponse
    {
        public SuccessUpdateEntryBodyCommandResponse(string message) : base(true, message)
        {
        }
    }

    public class ErrorUpdateEntryBodyCommandResponse : UpdateEntryBodyCommandResponse
    {
        public ErrorUpdateEntryBodyCommandResponse(string message) : base(false, message)
        {
        }
    }
}
