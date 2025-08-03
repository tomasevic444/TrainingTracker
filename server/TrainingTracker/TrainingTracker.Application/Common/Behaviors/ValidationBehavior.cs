using FluentValidation;
using MediatR;

namespace TrainingTracker.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            // If there are no validators for this request, just continue to the handler
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        // Run all validators and collect the results
        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        // Check for any validation failures
        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0)
        {
            // If there are failures, throw a ValidationException
            throw new ValidationException(failures);
        }

        // If validation succeeds, proceed to the actual request handler
        return await next();
    }
}