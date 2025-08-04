namespace TrainingTracker.Application.Workouts.Queries.GetWeeklySummary;

// This will hold the stats for a single week
public class WeeklySummaryDto
{
    public int WeekNumber { get; set; }
    public DateTime WeekStartDate { get; set; }
    public DateTime WeekEndDate { get; set; }
    public int TotalDurationInMinutes { get; set; }
    public int TotalWorkouts { get; set; }
    public double AverageIntensity { get; set; }
    public double AverageFatigue { get; set; }
}