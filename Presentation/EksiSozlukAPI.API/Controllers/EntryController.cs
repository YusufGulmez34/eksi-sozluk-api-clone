using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    }
}
