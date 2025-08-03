using MediatR;

namespace TrainingTracker.Application.Workouts.Commands.CreateWorkout;

// This command will return the Guid of the newly created workout
public class CreateWorkoutCommand : IRequest<Guid>
{
    // We don't need UserId here. We'll get it from the authenticated user's token.
    public required string ExerciseType { get; set; }
    public int DurationInMinutes { get; set; }
    public int CaloriesBurned { get; set; }
    public int Intensity { get; set; } // 1-10
    public int Fatigue { get; set; }   // 1-10
    public string? Notes { get; set; }
    public DateTime Date { get; set; }
}