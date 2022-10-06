using AutoMapper;
using EksiSozlukAPI.Application.DTOs;
using EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle;
using EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByChannelId;
using EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByJournal;
using EksiSozlukAPI.Application.Repositories.Title;
using EksiSozlukAPI.Application.Services;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleWriteRepository _titleWriteRepository;
        private readonly ITitleReadRepository _titleReadRepository;
        private readonly IMapper _mapper;

        public TitleService(ITitleWriteRepository titleRepository, IMapper mapper, ITitleReadRepository titleReadRepository)
        {
            _titleWriteRepository = titleRepository;
            _mapper = mapper;
            _titleReadRepository = titleReadRepository;
        }

        public async Task<CreateTitleCommandResponse> AddTitleAsync(CreateTitleCommandRequest createTitle)
        {
            E.Title title = _mapper.Map<E.Title>(createTitle);

            if (createTitle.Entry != null)
            {
                E.Entry entry = _mapper.Map<E.Entry>(createTitle.Entry);
                entry.FavCount = 0;
                title.Entries.Add(entry);
            }

            var result = await _titleWriteRepository.AddAsync(title);
            if (!result) return new ErrorCreateTitleCommandResponse("Error");

            await _titleWriteRepository.SaveAsync();
            return new SuccessCreateTitleCommandResponse("Success");
        }

        public async Task<GetTitlesByChannelIdQueryResponse> GetTitlesByChannelIdAsync(GetTitlesByChannelIdQueryRequest getTitles)
        {
            List<E.Title> titles = await _titleReadRepository.GetTitleListByChannelId(getTitles.ChannelId, getTitles.PageNumber, getTitles.PageSize);

            int totalCount = titles.Count;

            if (titles == null || titles.Count == 0) return new ErrorGetTitlesByChannelIdQueryResponse("Error");

            string baseUrl = $"https://localhost:7181/api/Title?ChannelId{getTitles.ChannelId}&";

            PagedData<List<TitleListItem>> pagedData = UrlGenerationService.UrlGenerator<List<TitleListItem>>(baseUrl, getTitles, totalCount);

            List<TitleListItem> titleList = _mapper.Map<List<TitleListItem>>(titles);

            pagedData.Data = titleList.Skip((getTitles.PageNumber - 1) * getTitles.PageSize).Take(getTitles.PageSize).ToList();

            return new SuccessGetTitlesByChannelIdQueryResponse(pagedData, "Success");
        }

        public async Task<GetTitlesByJournalQueryResponse> GetTitlesByJournalAsync(GetTitlesByJournalQueryRequest getTitles)
        {
            List<E.Title> titles = await _titleReadRepository.GetTitleListByJournal(getTitles.PageNumber, getTitles.PageSize);

            int totalCount = titles.Count;

            if (titles == null || titles.Count == 0) return new ErrorGetTitlesByJournalQueryResponse("Error");

            string baseUrl = $"https://localhost:7181/api/Title/journal?";

            PagedData <List<TitleListItem>> pagedData = UrlGenerationService.UrlGenerator<List<TitleListItem>>(baseUrl, getTitles, totalCount);

            List <TitleListItem> titleList = _mapper.Map<List<TitleListItem>>(titles);

            pagedData.Data = titleList.Skip((getTitles.PageNumber-1)*getTitles.PageSize).Take(getTitles.PageSize).ToList();

            return new SuccessGetTitlesByJournalQueryResponse(pagedData, "Success");
        }
    }
}
