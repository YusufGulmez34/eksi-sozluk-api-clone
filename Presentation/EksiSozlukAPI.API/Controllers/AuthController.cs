using EksiSozlukAPI.Application.Features.Commands.User.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozlukAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginUserCommandRequest userLogin)
        {
            LoginUserCommandResponse response = await _mediator.Send(userLogin);
            if (response == null) BadRequest();
            return Ok(response);
        }
    }
}
