using AutoMapper;
using EksiSozlukAPI.Application.DTOs;
using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
using EksiSozlukAPI.Application.Features.Commands.Entry.DeleteEntry;
using EksiSozlukAPI.Application.Features.Commands.Entry.FavEntry;
using EksiSozlukAPI.Application.Features.Commands.Entry.UpdateEntryBody;
using EksiSozlukAPI.Application.Features.Queries.Entry.GetEntryListByTitleId;
using EksiSozlukAPI.Application.Repositories.Entry;
using EksiSozlukAPI.Application.Services;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryWriteRepository _entryWriteRepository;
        private readonly IEntryReadRepository _entryReadRepository;

        private readonly IMapper _mapper;


        public EntryService(IEntryWriteRepository entryWriteRepository, IMapper mapper, IEntryReadRepository entryReadRepository)
        {
            _entryWriteRepository = entryWriteRepository;
            _mapper = mapper;
            _entryReadRepository = entryReadRepository;
        }

        public EntryService()
        {
        }

        public async Task<CreateEntryCommandResponse> AddEntryAsync(CreateEntryCommandRequest request)
        {
            E.Entry entry = _mapper.Map<E.Entry>(request);
            bool result = await _entryWriteRepository.AddAsync(entry);
            if (result) new ErrorCreateEntryCommandResponse("Error");

            await _entryWriteRepository.SaveAsync();
            return new SuccessCreateEntryCommandResponse("Success");
        }

        public async Task<FavEntryCommandResponse> FavEntryAsync(FavEntryCommandRequest request)
        {
            E.Entry entry = await _entryReadRepository.FindByIdAsync(request.Id);
            entry.FavCount++;
            bool result = _entryWriteRepository.Update(entry);
            if (!result) new ErrorFavEntryCommandResponse("Error");

            await _entryWriteRepository.SaveAsync();
            return new SuccessFavEntryCommandResponse("Success");

        }

        public async Task<GetEntryListByTitleIdQueryResponse> GetEntryListByTitleIdAsync(GetEntryListByTitleIdQueryRequest request)
        {
            List<E.Entry> entryList = _entryReadRepository.GetEntryListByTitleId(request.PageNumber, request.PageSize, request.TitleId).ToList();
            int totalCount = _entryReadRepository.Table.Where(e => e.TitleId == request.TitleId).Count();
            
            if (entryList == null || entryList.Count == 0)
            {
                return new ErrorGetEntryListByTitleIdQueryResponse("Error");
            }
            string baseUrl = $"https://localhost:7181/api/Entry?TitleId={request.TitleId}&";
            PagedData<List<EntryListItem>> pagedData = UrlGenerationService.UrlGenerator<List<EntryListItem>>(baseUrl, request, totalCount);

            pagedData.TotalRecords = totalCount;
            List <EntryListItem> entryListDto = _mapper.Map<List<EntryListItem>>(entryList);
            pagedData.Data = entryListDto;

            return new SuccessGetEntryListByTitleIdQueryResponse(pagedData, "Success");

        }

        public async Task<UpdateEntryBodyCommandResponse> UpdateEntryBodyAsync(UpdateEntryBodyCommandRequest request)
        {
            E.Entry entry = await _entryReadRepository.FindByIdAsync(request.EntryId);
            entry.Body = request.Body;
            bool result = _entryWriteRepository.Update(entry);
            if(!result) return new ErrorUpdateEntryBodyCommandResponse("Error");
            await _entryWriteRepository.SaveAsync();
            return new SuccessUpdateEntryBodyCommandResponse("Success");
        }

        public Uri GenerateUri(string TitleId, int PageSize, int PageNumber)
        {
            
            string baseUrl = "https://localhost:7181/api/Entry";
            return new Uri(baseUrl + $"?TitleId={TitleId}&PageSize={PageSize}&PageNumber={PageNumber}");
        }

        public async Task<DeleteEntryCommandResponse> DeleteEntry(DeleteEntryCommandRequest request)
        {
            bool result = await _entryWriteRepository.RemoveByIdAsync(request.Id);
            if(!result) return new ErrorDeleteEntryCommandResponse("Error");

            await _entryWriteRepository.SaveAsync();
            return new SuccessDeleteEntryCommandResponse("Success");
        }
    }
}
