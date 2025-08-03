using FluentValidation;

namespace TrainingTracker.Application.Workouts.Commands.CreateWorkout;

public class CreateWorkoutCommandValidator : AbstractValidator<CreateWorkoutCommand>
{
    public CreateWorkoutCommandValidator()
    {
        RuleFor(x => x.ExerciseType).NotEmpty();

        RuleFor(x => x.DurationInMinutes)
            .GreaterThan(0).WithMessage("Duration must be greater than 0.");

        RuleFor(x => x.CaloriesBurned)
            .GreaterThanOrEqualTo(0).WithMessage("Calories burned cannot be negative.");

        RuleFor(x => x.Intensity)
            .InclusiveBetween(1, 10).WithMessage("Intensity must be between 1 and 10.");

        RuleFor(x => x.Fatigue)
            .InclusiveBetween(1, 10).WithMessage("Fatigue must be between 1 and 10.");

        RuleFor(x => x.Date)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Workout date cannot be in the future.");
    }
}