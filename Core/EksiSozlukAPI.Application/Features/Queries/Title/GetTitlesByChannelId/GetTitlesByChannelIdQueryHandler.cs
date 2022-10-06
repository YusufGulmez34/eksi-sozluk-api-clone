using EksiSozlukAPI.Application.Services;
using MediatR;

namespace EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByChannelId
{
    public class GetTitlesByChannelIdQueryHandler : IRequestHandler<GetTitlesByChannelIdQueryRequest, GetTitlesByChannelIdQueryResponse>
    {
        private readonly ITitleService _titleService;

        public GetTitlesByChannelIdQueryHandler(ITitleService titleService)
        {
            _titleService = titleService;
        }
        public async Task<GetTitlesByChannelIdQueryResponse> Handle(GetTitlesByChannelIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _titleService.GetTitlesByChannelIdAsync(request);
        }
    }
}
