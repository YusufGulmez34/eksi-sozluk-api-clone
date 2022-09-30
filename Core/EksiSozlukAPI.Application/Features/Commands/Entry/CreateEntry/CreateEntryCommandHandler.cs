using EksiSozlukAPI.Application.Services;
using MediatR;

namespace EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry
{
    public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommandRequest, CreateEntryCommandResponse>
    {
        private readonly IEntryService _entryService;

        public CreateEntryCommandHandler(IEntryService entryService)
        {
            _entryService = entryService;
        }

        public async Task<CreateEntryCommandResponse> Handle(CreateEntryCommandRequest request, CancellationToken cancellationToken)
        {
            return await _entryService.AddEntryAsync(request);
        }
    }
}
