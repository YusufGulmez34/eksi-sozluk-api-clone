using EksiSozlukAPI.Application.DTOs;

namespace EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByChannelId
{
    public class GetTitlesByChannelIdQueryResponse : ResponseData<PagedData<List<TitleListItem>>>
    {
        public GetTitlesByChannelIdQueryResponse(PagedData<List<TitleListItem>> data, bool success, string message) : base(data, success, message)
        {
        }
    }

    public class SuccessGetTitlesByChannelIdQueryResponse : GetTitlesByChannelIdQueryResponse
    {
        public SuccessGetTitlesByChannelIdQueryResponse(PagedData<List<TitleListItem>> data, string message) : base(data, true, message)
        {
        }
    }

    public class ErrorGetTitlesByChannelIdQueryResponse : GetTitlesByChannelIdQueryResponse
    {
        public ErrorGetTitlesByChannelIdQueryResponse(string message) : base(null, false, message)
        {
        }
    }
}