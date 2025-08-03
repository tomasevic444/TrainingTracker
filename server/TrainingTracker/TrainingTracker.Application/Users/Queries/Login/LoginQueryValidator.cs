using FluentValidation;

namespace TrainingTracker.Application.Users.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.LoginIdentifier)
            .NotEmpty().WithMessage("Username or email is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}