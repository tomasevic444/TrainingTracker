using TrainingTracker.Core.Entities;

namespace TrainingTracker.Application.Common.Interfaces;

public interface IWorkoutRepository
{
    void Add(Workout workout);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
}