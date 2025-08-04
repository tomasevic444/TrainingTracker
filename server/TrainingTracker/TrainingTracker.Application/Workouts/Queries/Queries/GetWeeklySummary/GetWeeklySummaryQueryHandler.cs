using MediatR;
using System.Globalization;
using TrainingTracker.Application.Common.Interfaces;

namespace TrainingTracker.Application.Workouts.Queries.GetWeeklySummary;

public class GetWeeklySummaryQueryHandler : IRequestHandler<GetWeeklySummaryQuery, IEnumerable<WeeklySummaryDto>>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IUserContext _userContext;

    public GetWeeklySummaryQueryHandler(IWorkoutRepository workoutRepository, IUserContext userContext)
    {
        _workoutRepository = workoutRepository;
        _userContext = userContext;
    }

    public async Task<IEnumerable<WeeklySummaryDto>> Handle(GetWeeklySummaryQuery request, CancellationToken cancellationToken)
    {
        var userId = _userContext.GetUserId();
        if (userId is null)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        // 1. Determine the date range for the requested month
        var startDate = new DateTime(request.Year, request.Month, 1, 0, 0, 0, DateTimeKind.Utc);

        var endDate = startDate.AddMonths(1);

        // 2. Fetch all workouts for that month
        var workouts = await _workoutRepository.GetWorkoutsByDateRangeAsync(userId.Value, startDate, endDate, cancellationToken);

        if (!workouts.Any())
        {
            return Enumerable.Empty<WeeklySummaryDto>();
        }

        // 3. Group workouts by week number
        var weeklyGroups = workouts.GroupBy(w => GetWeekOfYear(w.Date));

        // 4. Process each group to calculate statistics
        var summaries = weeklyGroups.Select(group =>
        {
            var firstDayOfWeek = group.Min(w => w.Date);
            var weekNumber = GetWeekOfYear(firstDayOfWeek);

            return new WeeklySummaryDto
            {
                WeekNumber = weekNumber,
                WeekStartDate = GetStartOfWeek(firstDayOfWeek, DayOfWeek.Monday),
                WeekEndDate = GetStartOfWeek(firstDayOfWeek, DayOfWeek.Monday).AddDays(6),
                TotalDurationInMinutes = group.Sum(w => w.DurationInMinutes),
                TotalWorkouts = group.Count(),
                AverageIntensity = group.Average(w => w.Intensity),
                AverageFatigue = group.Average(w => w.Fatigue)
            };
        }).OrderBy(s => s.WeekNumber).ToList();

        return summaries;
    }

    // Helper method to get the ISO 8601 week number of a year
    private static int GetWeekOfYear(DateTime date)
    {
        // This is a standard way to calculate the week number where Monday is the first day of the week.
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            date = date.AddDays(3);
        }

        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    // Helper method to get the start date of the week
    private static DateTime GetStartOfWeek(DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }
}