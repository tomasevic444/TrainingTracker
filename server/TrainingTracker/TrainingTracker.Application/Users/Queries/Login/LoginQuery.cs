using MediatR;

namespace TrainingTracker.Application.Users.Queries.Login;

// A query that will return a string (the JWT token)
public class LoginQuery : IRequest<string>
{
    public required string LoginIdentifier { get; set; }
    public required string Password { get; set; }
}