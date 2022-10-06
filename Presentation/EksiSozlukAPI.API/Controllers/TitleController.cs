using EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle;
using EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByChannelId;
using EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByJournal;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "user", AuthenticationSchemes = "admin")]
        public async Task<IActionResult> CreateTitle(CreateTitleCommandRequest createTitle)
        {
            CreateTitleCommandResponse response = await _mediator.Send(createTitle);

            if (response == null) BadRequest();

            return Ok(response);
        }

        [HttpGet("journal")]
        public async Task<IActionResult> GetTitleByJoural([FromQuery] GetTitlesByJournalQueryRequest request)
        {
            GetTitlesByJournalQueryResponse response = await _mediator.Send(request);

            if (response == null) BadRequest();

            return Ok(response);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTitleByChannelId([FromQuery] GetTitlesByChannelIdQueryRequest request)
        {
            GetTitlesByChannelIdQueryResponse response = await _mediator.Send(request);

            if (response == null) BadRequest();

            return Ok(response);
        }
    }
}
