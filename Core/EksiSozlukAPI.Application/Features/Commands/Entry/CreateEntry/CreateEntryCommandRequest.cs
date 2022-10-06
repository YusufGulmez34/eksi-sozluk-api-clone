using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry
{
    public class CreateEntryCommandRequest : IRequest<CreateEntryCommandResponse>
    {
        public string Body { get; set; }
        public int? TitleId { get; set; }
        public int UserId { get; set; }
    }
}
