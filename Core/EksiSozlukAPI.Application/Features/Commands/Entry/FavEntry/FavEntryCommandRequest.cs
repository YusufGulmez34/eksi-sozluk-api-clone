using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.Entry.FavEntry
{
    public class FavEntryCommandRequest : IRequest<FavEntryCommandResponse>
    {
        public int Id { get; set; }
    }
}
