// 1. ADD THESE USING STATEMENTS AT THE TOP
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingTracker.Application.Workouts.Commands.CreateWorkout;
using TrainingTracker.Application.Workouts.Queries.GetUserWorkouts;
using TrainingTracker.Application.Workouts.Queries.GetWeeklySummary;

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
        [HttpGet] // This will map to GET /api/workouts
        public async Task<IActionResult> GetUserWorkouts()
        {
            var query = new GetUserWorkoutsQuery();
            var workouts = await _mediator.Send(query);
            return Ok(workouts);
        }
        [HttpGet("summary")] // Maps to GET /api/workouts/summary?year=2024&month=8
        public async Task<IActionResult> GetWeeklySummary([FromQuery] GetWeeklySummaryQuery query)
        {
            var summary = await _mediator.Send(query);
            return Ok(summary);
        }

    }
}