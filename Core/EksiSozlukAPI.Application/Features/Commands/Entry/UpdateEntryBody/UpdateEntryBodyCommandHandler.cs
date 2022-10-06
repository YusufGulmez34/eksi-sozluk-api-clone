using EksiSozlukAPI.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.Entry.UpdateEntryBody
{
    public class UpdateEntryBodyCommandHandler : IRequestHandler<UpdateEntryBodyCommandRequest, UpdateEntryBodyCommandResponse>
    {
        private readonly IEntryService _entryService;

        public UpdateEntryBodyCommandHandler(IEntryService entryService)
        {
            _entryService = entryService;
        }

        public async Task<UpdateEntryBodyCommandResponse> Handle(UpdateEntryBodyCommandRequest request, CancellationToken cancellationToken)
        {
            return await _entryService.UpdateEntryBodyAsync(request);
        }
    }
}
