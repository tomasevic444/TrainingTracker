using MediatR;
using TrainingTracker.Application.Users.Commands.RegisterUser;
using TrainingTracker.Core.Entities;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.UserExistsAsync(request.Email, cancellationToken))
        {
            throw new Exception("User with this email already exists.");
        }

        if (await _userRepository.UsernameExistsAsync(request.Username, cancellationToken))
        {
            throw new Exception("This username is already taken.");
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username, 
            Email = request.Email,
            PasswordHash = passwordHash
        };

        _userRepository.Add(user);
        await _userRepository.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}