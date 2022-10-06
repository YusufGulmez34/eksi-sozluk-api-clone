using EksiSozlukAPI.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByJournal
{
    public class GetTitleByJournalQueryHandler : IRequestHandler<GetTitlesByJournalQueryRequest, GetTitlesByJournalQueryResponse>
    {
        private readonly ITitleService _titleService;

        public GetTitleByJournalQueryHandler(ITitleService titleService)
        {
            _titleService = titleService;
        }

        public async Task<GetTitlesByJournalQueryResponse> Handle(GetTitlesByJournalQueryRequest request, CancellationToken cancellationToken)
        {
            return await _titleService.GetTitlesByJournalAsync(request);
        }
    }
}
