using EksiSozlukAPI.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Queries.Entry.GetEntryListByTitleId
{
    public class GetEntryListByTitleIdQueryHandler : IRequestHandler<GetEntryListByTitleIdQueryRequest, GetEntryListByTitleIdQueryResponse>
    {
        private readonly IEntryService _entryService;

        public GetEntryListByTitleIdQueryHandler(IEntryService entryService)
        {
            _entryService = entryService;
        }

        public async Task<GetEntryListByTitleIdQueryResponse> Handle(GetEntryListByTitleIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _entryService.GetEntryListByTitleId(request);
        }
    }
}
