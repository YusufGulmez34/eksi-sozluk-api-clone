using AutoMapper;
using EksiSozlukAPI.Application.DTOs;
using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
using EksiSozlukAPI.Application.Features.Commands.Entry.FavEntry;
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
            List<E.Entry> entryList = _entryReadRepository.GetEntryListByTitleId(request.TitleId);
            if (entryList == null || entryList.Count == 0)
            {
                return new ErrorGetEntryListByTitleIdQueryResponse("Error");
            }
            List<EntryListItem> entryListDto = _mapper.Map<List<EntryListItem>>(entryList);

            return new SuccessGetEntryListByTitleIdQueryResponse(entryListDto, "Success");

        }
    }
}
