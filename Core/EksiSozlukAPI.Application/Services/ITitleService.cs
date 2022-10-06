using EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle;
using EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByChannelId;
using EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByJournal;

namespace EksiSozlukAPI.Application.Services
{
    public interface ITitleService
    {
        Task<CreateTitleCommandResponse> AddTitleAsync(CreateTitleCommandRequest createTitle);
        Task<GetTitlesByJournalQueryResponse> GetTitlesByJournalAsync(GetTitlesByJournalQueryRequest getTitles);
        Task<GetTitlesByChannelIdQueryResponse> GetTitlesByChannelIdAsync(GetTitlesByChannelIdQueryRequest getTitles);

    }
}
