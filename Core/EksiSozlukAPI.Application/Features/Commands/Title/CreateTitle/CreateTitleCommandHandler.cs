using EksiSozlukAPI.Application.Services;
using MediatR;

namespace EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle
{
    public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommandRequest, CreateTitleCommandResponse>
    {
        private readonly ITitleService _titleService;

        public CreateTitleCommandHandler(ITitleService titleService)
        {
            _titleService = titleService;
        }

        public async Task<CreateTitleCommandResponse> Handle(CreateTitleCommandRequest request, CancellationToken cancellationToken)
        {
            return await _titleService.AddTitleAsync(request);
        }
    }
}
