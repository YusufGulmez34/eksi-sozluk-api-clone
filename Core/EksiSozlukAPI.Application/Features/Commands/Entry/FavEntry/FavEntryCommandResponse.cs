using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.Entry.FavEntry
{
    public class FavEntryCommandResponse : Response
    {
        public FavEntryCommandResponse(bool success, string message) : base(success, message)
        {
        }
    }
    public class SuccessFavEntryCommandResponse : FavEntryCommandResponse
    {
        public SuccessFavEntryCommandResponse(string message) : base(true, message)
        {
        }
    }
    public class ErrorFavEntryCommandResponse : FavEntryCommandResponse
    {
        public ErrorFavEntryCommandResponse(string message) : base(false, message)
        {
        }
    }
}
