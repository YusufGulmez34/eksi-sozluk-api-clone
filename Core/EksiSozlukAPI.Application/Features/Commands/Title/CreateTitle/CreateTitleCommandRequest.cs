using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
using MediatR;

namespace EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle
{
    public class CreateTitleCommandRequest : IRequest<CreateTitleCommandResponse>
    {
        public string Name { get; set; }
        public int ChannelId { get; set; }
        public CreateEntryCommandRequest Entry { get; set; }
    }
}
