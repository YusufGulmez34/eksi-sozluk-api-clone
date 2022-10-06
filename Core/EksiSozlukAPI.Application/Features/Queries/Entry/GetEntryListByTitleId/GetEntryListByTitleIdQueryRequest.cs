using MediatR;

namespace EksiSozlukAPI.Application.Features.Queries.Entry.GetEntryListByTitleId
{
    public class GetEntryListByTitleIdQueryRequest : PageFilter, IRequest<GetEntryListByTitleIdQueryResponse>
    {
        public GetEntryListByTitleIdQueryRequest() :base()
        {

        }
        public GetEntryListByTitleIdQueryRequest(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }

        public int TitleId { get; set; }
    }
}
