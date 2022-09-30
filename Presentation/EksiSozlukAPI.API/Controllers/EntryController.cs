using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
using EksiSozlukAPI.Application.Features.Commands.Entry.FavEntry;
using EksiSozlukAPI.Application.Features.Queries.Entry.GetEntryListByTitleId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozlukAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntry(CreateEntryCommandRequest request)
        {
            CreateEntryCommandResponse response = await _mediator.Send(request);

            if (response == null) BadRequest();

            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> FavEntry([FromRoute] FavEntryCommandRequest request)
        {
            FavEntryCommandResponse response = await _mediator.Send(request);

            if (response == null) BadRequest();

            return Ok(response);
        }

        [HttpGet("titles/{TitleId}")]
        public async Task<IActionResult> GetEntryListByTitleId([FromRoute] GetEntryListByTitleIdQueryRequest request)
        {
            GetEntryListByTitleIdQueryResponse response = await _mediator.Send(request);

            if (response == null) BadRequest();

            return Ok(response);
        }
    }
}
