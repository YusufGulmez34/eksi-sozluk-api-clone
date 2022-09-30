
using EksiSozlukAPI.Application.Features.Commands.User.CreateUser;
using EksiSozlukAPI.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EksiSozlukAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "user", AuthenticationSchemes = "admin")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUser)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUser);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
