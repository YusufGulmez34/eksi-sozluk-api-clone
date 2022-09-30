using MediatR;

namespace EksiSozlukAPI.Application.Features.Queries.Entry.GetEntryListByTitleId
{
    public class GetEntryListByTitleIdQueryRequest : IRequest<GetEntryListByTitleIdQueryResponse>
    {
        public string TitleId { get; set; }
    }
}
