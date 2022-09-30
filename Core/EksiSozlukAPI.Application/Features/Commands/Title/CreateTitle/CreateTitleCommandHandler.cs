using EksiSozlukAPI.Application.Services.Title;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
