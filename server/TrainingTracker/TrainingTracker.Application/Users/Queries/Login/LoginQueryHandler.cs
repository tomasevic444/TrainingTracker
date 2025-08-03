using MediatR;
using TrainingTracker.Application.Common.Interfaces;

namespace TrainingTracker.Application.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // 1. Get user by email OR username
        var user = await _userRepository.FindUserByLoginIdentifierAsync(request.LoginIdentifier, cancellationToken);

        if (user is null)
        {
            throw new Exception("Invalid credentials.");
        }

        // 2. Verify password
        var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!isPasswordValid)
        {
            throw new Exception("Invalid credentials.");
        }

        // 3. Generate JWT
        var token = _jwtTokenGenerator.GenerateToken(user);

        return token;
    }
}