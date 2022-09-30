using AutoMapper;
using EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle;
using EksiSozlukAPI.Application.Repositories.Title;
using EksiSozlukAPI.Application.Services.Title;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Services.Title
{
    public class TitleService : ITitleService
    {
        private readonly ITitleWriteRepository _titleWriteRepository;
        private readonly IMapper _mapper;

        public TitleService(ITitleWriteRepository titleRepository, IMapper mapper)
        {
            _titleWriteRepository = titleRepository;
            _mapper = mapper;
        }

        public async Task<CreateTitleCommandResponse> AddTitleAsync(CreateTitleCommandRequest createTitle)
        {
            E.Title title = _mapper.Map<E.Title>(createTitle);
            E.Entry entry;

            if (createTitle.Entry != null)
            {
                entry = _mapper.Map<E.Entry>(createTitle.Entry);
                entry.FavCount = 0;
                title.Entries.Add(entry);
            }

            var result = await _titleWriteRepository.AddAsync(title);
            if (!result) return new ErrorCreateTitleCommandResponse("Error");

            await _titleWriteRepository.SaveAsync();
            return new SuccessCreateTitleCommandResponse("Success");
        }
    }
}
