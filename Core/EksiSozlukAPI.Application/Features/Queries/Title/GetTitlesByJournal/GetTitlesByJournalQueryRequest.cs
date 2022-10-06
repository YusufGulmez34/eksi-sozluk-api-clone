using MediatR;

namespace EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByJournal
{
    public class GetTitlesByJournalQueryRequest : PageFilter, IRequest<GetTitlesByJournalQueryResponse>
    {
        public GetTitlesByJournalQueryRequest() : base()
        {
        }

        public GetTitlesByJournalQueryRequest(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }
    }
}
