using Microsoft.EntityFrameworkCore;
using TrainingTracker.Core.Entities;

namespace TrainingTracker.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> UserExistsAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
    public async Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower(), cancellationToken);
    }

    public async Task<User?> FindUserByLoginIdentifierAsync(string identifier, CancellationToken cancellationToken)
    {
        var normalizedIdentifier = identifier.ToLower();

        return await _context.Users
            .SingleOrDefaultAsync(u => u.Email.ToLower() == normalizedIdentifier || u.Username.ToLower() == normalizedIdentifier, cancellationToken);
    }
}