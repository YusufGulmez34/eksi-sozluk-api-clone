using EksiSozlukAPI.Application.DTOs;

namespace EksiSozlukAPI.Application.Features.Queries.Entry.GetEntryListByTitleId
{
    public class GetEntryListByTitleIdQueryResponse : ResponseData<PagedData<List<EntryListItem>>>
    {
        public GetEntryListByTitleIdQueryResponse(PagedData<List<EntryListItem>> data, bool success, string message) : base(data, success, message)
        {
        }
    }
    public class SuccessGetEntryListByTitleIdQueryResponse : GetEntryListByTitleIdQueryResponse
    {
        public SuccessGetEntryListByTitleIdQueryResponse(PagedData<List<EntryListItem>> data, string message) : base(data, true, message)
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
