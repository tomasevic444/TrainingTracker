using MediatR;
using TrainingTracker.Application.Common.Interfaces;
using TrainingTracker.Core.Entities;

namespace TrainingTracker.Application.Workouts.Commands.CreateWorkout;

public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, Guid>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IUserContext _userContext;

    public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository, IUserContext userContext)
    {
        _workoutRepository = workoutRepository;
        _userContext = userContext;
    }

    public async Task<Guid> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var userId = _userContext.GetUserId();

        if (userId is null)
        {
            // This should technically not happen if the endpoint is protected by [Authorize]
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var workout = new Workout
        {
            Id = Guid.NewGuid(),
            UserId = userId.Value, // .Value is needed because userId is a Guid? (nullable Guid)
            ExerciseType = request.ExerciseType,
            DurationInMinutes = request.DurationInMinutes,
            CaloriesBurned = request.CaloriesBurned,
            Intensity = request.Intensity,
            Fatigue = request.Fatigue,
            Notes = request.Notes,
            Date = request.Date.ToUniversalTime() // Always store dates in UTC
        };

        _workoutRepository.Add(workout);
        await _workoutRepository.SaveChangesAsync(cancellationToken);

        return workout.Id;
    }
}