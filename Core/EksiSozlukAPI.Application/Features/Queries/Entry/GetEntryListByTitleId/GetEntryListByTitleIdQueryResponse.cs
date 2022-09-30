using EksiSozlukAPI.Application.DTOs;

namespace EksiSozlukAPI.Application.Features.Queries.Entry.GetEntryListByTitleId
{
    public class GetEntryListByTitleIdQueryResponse : ResponseData<List<EntryListItem>>
    {
        public GetEntryListByTitleIdQueryResponse(List<EntryListItem> data, bool success, string message) : base(data, success, message)
        {
        }
    }
    public class SuccessGetEntryListByTitleIdQueryResponse : GetEntryListByTitleIdQueryResponse
    {
        public SuccessGetEntryListByTitleIdQueryResponse(List<EntryListItem> data, string message) : base(data, true, message)
        {
        }
    }

    public class ErrorGetEntryListByTitleIdQueryResponse : GetEntryListByTitleIdQueryResponse
    {
        public ErrorGetEntryListByTitleIdQueryResponse(string message) : base(null, false, message)
        {
        }
    }
}
