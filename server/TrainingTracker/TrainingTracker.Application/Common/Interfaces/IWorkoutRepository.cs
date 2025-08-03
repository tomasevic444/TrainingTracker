using TrainingTracker.Core.Entities;

namespace TrainingTracker.Application.Common.Interfaces;

public interface IWorkoutRepository
{
    void Add(Workout workout);
    Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
}