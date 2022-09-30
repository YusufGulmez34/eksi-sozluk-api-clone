using AutoMapper;
using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
using EksiSozlukAPI.Application.Repositories.Entry;
using EksiSozlukAPI.Application.Services;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryWriteRepository _entryWriteRepository;
        private readonly IMapper _mapper;


        public EntryService(IEntryWriteRepository entryWriteRepository, IMapper mapper)
        {
            _entryWriteRepository = entryWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateEntryCommandResponse> AddEntryAsync(CreateEntryCommandRequest request)
        {
            E.Entry entry = _mapper.Map<E.Entry>(request);
            bool result = await _entryWriteRepository.AddAsync(entry);
            if (result) new ErrorCreateEntryCommandResponse("Error");
            
            await _entryWriteRepository.SaveAsync();
            return new SuccessCreateEntryCommandResponse("Success");
        }
    }
}
