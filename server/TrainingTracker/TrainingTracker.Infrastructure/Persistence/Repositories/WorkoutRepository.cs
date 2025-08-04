using Microsoft.EntityFrameworkCore;
using TrainingTracker.Application.Common.Interfaces;
using TrainingTracker.Core.Entities;

namespace TrainingTracker.Infrastructure.Persistence.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly ApplicationDbContext _context;

    public WorkoutRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Workout workout)
    {
        _context.Workouts.Add(workout);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
    public async Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Workouts
            .Where(w => w.UserId == userId)
            .OrderByDescending(w => w.Date) // Return the most recent workouts first
            .ToListAsync(cancellationToken);
    }
    public async Task<IEnumerable<Workout>> GetWorkoutsByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
    {
        return await _context.Workouts
            .Where(w => w.UserId == userId && w.Date >= startDate && w.Date < endDate)
            .ToListAsync(cancellationToken);
    }
}