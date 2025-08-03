using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingTracker.Application.Users.Commands.RegisterUser;

namespace TrainingTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _mediator;

        public UsersController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            try
            {
                var userId = await _mediator.Send(command);
                return CreatedAtAction(nameof(Register), new { id = userId }, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}