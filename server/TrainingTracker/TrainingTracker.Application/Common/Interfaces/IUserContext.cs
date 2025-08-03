namespace TrainingTracker.Application.Common.Interfaces;

public interface IUserContext
{
    Guid? GetUserId(); // The ID might be null if the user is not authenticated
}