using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
using EksiSozlukAPI.Application.Features.Commands.Entry.DeleteEntry;
using EksiSozlukAPI.Application.Features.Commands.Entry.FavEntry;
using EksiSozlukAPI.Application.Features.Commands.Entry.UpdateEntryBody;
using EksiSozlukAPI.Application.Features.Queries.Entry.GetEntryListByTitleId;

namespace EksiSozlukAPI.Application.Services
{
    public interface IEntryService
    {
        Task<CreateEntryCommandResponse> AddEntryAsync(CreateEntryCommandRequest request);
        Task<FavEntryCommandResponse> FavEntryAsync(FavEntryCommandRequest request);
        Task<GetEntryListByTitleIdQueryResponse> GetEntryListByTitleIdAsync(GetEntryListByTitleIdQueryRequest request);
        Task<UpdateEntryBodyCommandResponse> UpdateEntryBodyAsync(UpdateEntryBodyCommandRequest request);
        Task<DeleteEntryCommandResponse> DeleteEntry(DeleteEntryCommandRequest request);


    }
}
