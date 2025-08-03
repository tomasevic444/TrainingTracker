using TrainingTracker.Core.Entities;

public interface IUserRepository
{
    Task<bool> UserExistsAsync(string email, CancellationToken cancellationToken);
    Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken);

    Task<User?> FindUserByLoginIdentifierAsync(string identifier, CancellationToken cancellationToken);

    void Add(User user);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
}