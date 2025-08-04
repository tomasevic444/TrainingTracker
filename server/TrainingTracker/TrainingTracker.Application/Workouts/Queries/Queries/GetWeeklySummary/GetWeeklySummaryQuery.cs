using MediatR;

namespace TrainingTracker.Application.Workouts.Queries.GetWeeklySummary;

// This query takes a year and month and returns a list of weekly summaries
public class GetWeeklySummaryQuery : IRequest<IEnumerable<WeeklySummaryDto>>
{
    public int Year { get; set; }
    public int Month { get; set; }
}