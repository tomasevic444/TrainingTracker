using MediatR;
using TrainingTracker.Application.Common.Interfaces;

namespace TrainingTracker.Application.Workouts.Queries.GetUserWorkouts;

public class GetUserWorkoutsQueryHandler : IRequestHandler<GetUserWorkoutsQuery, IEnumerable<WorkoutDto>>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IUserContext _userContext;

    public GetUserWorkoutsQueryHandler(IWorkoutRepository workoutRepository, IUserContext userContext)
    {
        _workoutRepository = workoutRepository;
        _userContext = userContext;
    }

    public async Task<IEnumerable<WorkoutDto>> Handle(GetUserWorkoutsQuery request, CancellationToken cancellationToken)
    {
        var userId = _userContext.GetUserId();

        if (userId is null)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var workouts = await _workoutRepository.GetWorkoutsByUserIdAsync(userId.Value, cancellationToken);

        // Map the Workout entities to WorkoutDto objects
        var workoutDtos = workouts.Select(workout => new WorkoutDto
        {
            Id = workout.Id,
            ExerciseType = workout.ExerciseType,
            DurationInMinutes = workout.DurationInMinutes,
            CaloriesBurned = workout.CaloriesBurned,
            Intensity = workout.Intensity,
            Fatigue = workout.Fatigue,
            Notes = workout.Notes,
            Date = workout.Date
        });

        return workoutDtos;
    }
}