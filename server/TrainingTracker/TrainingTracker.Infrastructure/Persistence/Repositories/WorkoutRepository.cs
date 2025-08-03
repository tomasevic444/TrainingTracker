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
}