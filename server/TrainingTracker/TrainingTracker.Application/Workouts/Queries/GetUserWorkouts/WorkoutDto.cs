namespace TrainingTracker.Application.Workouts.Queries.GetUserWorkouts;

public class WorkoutDto
{
    public Guid Id { get; set; }
    public required string ExerciseType { get; set; }
    public int DurationInMinutes { get; set; }
    public int CaloriesBurned { get; set; }
    public int Intensity { get; set; }
    public int Fatigue { get; set; }
    public string? Notes { get; set; }
    public DateTime Date { get; set; }
}