using MediatR;

namespace TrainingTracker.Application.Workouts.Queries.GetUserWorkouts;

// This query will return a list of our DTOs
public class GetUserWorkoutsQuery : IRequest<IEnumerable<WorkoutDto>>
{
    // This query doesn't need any parameters, because the user ID
    // will be retrieved from the user context.
}