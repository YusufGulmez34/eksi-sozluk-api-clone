using EksiSozlukAPI.Application.Services;
using MediatR;

namespace EksiSozlukAPI.Application.Features.Commands.Entry.DeleteEntry
{
    public class DeleteEntryCommandHandler : IRequestHandler<DeleteEntryCommandRequest, DeleteEntryCommandResponse>
    {
        private readonly IEntryService _entryService;

        public DeleteEntryCommandHandler(IEntryService entryService)
        {
            _entryService = entryService;
        }
        public async Task<DeleteEntryCommandResponse> Handle(DeleteEntryCommandRequest request, CancellationToken cancellationToken)
        {
            return await _entryService.DeleteEntry(request);
        }
    }
}
