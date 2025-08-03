using TrainingTracker.Core.Entities;

namespace TrainingTracker.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}