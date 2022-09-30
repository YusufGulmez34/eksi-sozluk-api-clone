using EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozlukAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TitleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTitle(CreateTitleCommandRequest createTitle)
        {
            CreateTitleCommandResponse response = await _mediator.Send(createTitle);

            if (response == null) BadRequest();

            return Ok(response);
        }
    }
}
