using AutoMapper;
using EksiSozlukAPI.Application.DTOs;
using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
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

        public async Task<GetEntryListByTitleIdQueryResponse> GetEntryListByTitleId(GetEntryListByTitleIdQueryRequest request)
        {
            List<E.Entry> entryList = _entryReadRepository.GetEntryListByTitleId(request.PageNumber, request.PageSize, request.TitleId).ToList();
            int totalCount = _entryReadRepository.Table.Count();
            
            if (entryList == null || entryList.Count == 0)
            {
                return new ErrorGetEntryListByTitleIdQueryResponse("Error");
            }
            PagedData<List<EntryListItem>> pagedData = new();
            pagedData.PageNumber = request.PageNumber;
            
            pagedData.TotalPages = (totalCount % request.PageSize) > 0 
                                    ? totalCount / request.PageSize + 1 
                                    : totalCount/ request.PageSize;

            pagedData.FirstPage = pagedData.PageNumber == 1 
                                    ? null 
                                    : GenerateUri(request.TitleId, request.PageSize, 1);

            pagedData.NextPage = pagedData.PageNumber == pagedData.TotalPages 
                                    ? null 
                                    : GenerateUri(request.TitleId, request.PageSize, pagedData.PageNumber + 1);

            pagedData.PreviousPage = pagedData.PageNumber == 1
                                    ? null
                                    : GenerateUri(request.TitleId, request.PageSize, pagedData.PageNumber - 1);

            pagedData.LastPage = pagedData.PageNumber == pagedData.TotalPages
                                    ? null
                                    : GenerateUri(request.TitleId, request.PageSize, pagedData.TotalPages);

            pagedData.TotalRecords = totalCount;
            List <EntryListItem> entryListDto = _mapper.Map<List<EntryListItem>>(entryList);
            pagedData.Data = entryListDto;

            return new SuccessGetEntryListByTitleIdQueryResponse(pagedData, "Success");

        }

        public async Task<UpdateEntryBodyCommandResponse> UpdateEntryBody(UpdateEntryBodyCommandRequest request)
        {
            E.Entry entry = await _entryReadRepository.FindByIdAsync(request.EntryId.ToString());
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
    }
}
