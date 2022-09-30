using EksiSozlukAPI.Application.Services;
using MediatR;
namespace EksiSozlukAPI.Application.Features.Commands.Entry.FavEntry
{
    public class FavEntryCommandHandler : IRequestHandler<FavEntryCommandRequest, FavEntryCommandResponse>
    {
        private readonly IEntryService _entryService;

        public FavEntryCommandHandler(IEntryService entryService)
        {
            _entryService = entryService;
        }

        public async Task<FavEntryCommandResponse> Handle(FavEntryCommandRequest request, CancellationToken cancellationToken)
        {
            return await _entryService.FavEntryAsync(request);
        }
    }
}
