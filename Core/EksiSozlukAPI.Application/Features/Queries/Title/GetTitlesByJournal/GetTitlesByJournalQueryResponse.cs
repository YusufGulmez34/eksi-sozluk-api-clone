using EksiSozlukAPI.Application.DTOs;

namespace EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByJournal
{
    public class GetTitlesByJournalQueryResponse : ResponseData<PagedData<List<TitleListItem>>>
    {
        public GetTitlesByJournalQueryResponse(PagedData<List<TitleListItem>> data, bool success, string message) : base(data, success, message)
        {
        }
    }
    public class SuccessGetTitlesByJournalQueryResponse : GetTitlesByJournalQueryResponse
    {
        public SuccessGetTitlesByJournalQueryResponse(PagedData<List<TitleListItem>> data, string message) : base(data, true, message)
        {
        }
    }

    public class ErrorGetTitlesByJournalQueryResponse : GetTitlesByJournalQueryResponse
    {
        public ErrorGetTitlesByJournalQueryResponse(string message) : base(null, true, message)
        {
        }
    }
}
