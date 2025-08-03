// 1. ADD THESE USING STATEMENTS AT THE TOP
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingTracker.Application.Workouts.Commands.CreateWorkout;

namespace TrainingTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkoutsController : ControllerBase
    {
        private readonly ISender _mediator;

        public WorkoutsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout(CreateWorkoutCommand command)
        {
            var workoutId = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateWorkout), new { id = workoutId }, workoutId);
        }
    }
}