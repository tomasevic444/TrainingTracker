namespace TrainingTracker.Core.Entities;

public class Workout
{
    public Guid Id { get; set; }
    public required string ExerciseType { get; set; }
    public int DurationInMinutes { get; set; }
    public int CaloriesBurned { get; set; }
    public int Intensity { get; set; } // 1-10
    public int Fatigue { get; set; } // 1-10
    public string? Notes { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}