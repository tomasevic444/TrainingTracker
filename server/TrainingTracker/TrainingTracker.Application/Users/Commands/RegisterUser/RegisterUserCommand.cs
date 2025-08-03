using MediatR;

namespace TrainingTracker.Application.Users.Commands.RegisterUser;

// IRequest<Guid> means that executing this command will return a Guid (the ID of the new user)
public class RegisterUserCommand : IRequest<Guid>
{
    public required string Username { get; set; } 
    public required string Email { get; set; }
    public required string Password { get; set; }
}