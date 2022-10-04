using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.Entry.UpdateEntryBody
{
    public class UpdateEntryBodyCommandRequest : IRequest<UpdateEntryBodyCommandResponse>
    {
        public Guid EntryId { get; set; }
        public string Body { get; set; }
    }
}
