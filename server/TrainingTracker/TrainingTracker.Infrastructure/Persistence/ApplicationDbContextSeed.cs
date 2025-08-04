using TrainingTracker.Core.Entities;

namespace TrainingTracker.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seeding should only happen if the database is empty.
        if (context.Users.Any())
        {
            return; // DB has been seeded
        }

        // 1. Create a sample user
        var sampleUser = new User
        {
            Id = Guid.NewGuid(),
            Username = "testuser",
            Email = "test@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123!")
        };

        context.Users.Add(sampleUser);
        await context.SaveChangesAsync(); // Save the user to get a valid UserId for workouts

        // 2. Create sample workouts for the user for the last few months
        var workouts = new List<Workout>();
        var random = new Random();
        var today = DateTime.UtcNow;

        for (int i = 0; i < 90; i++) // Create 90 workouts over the last 90 days
        {
            // Skip some days to make it more realistic
            if (random.Next(10) < 4) continue;

            var workoutDate = today.AddDays(-i);

            workouts.Add(new Workout
            {
                Id = Guid.NewGuid(),
                UserId = sampleUser.Id,
                ExerciseType = GetRandomExerciseType(random),
                DurationInMinutes = random.Next(20, 91), // 20 to 90 minutes
                CaloriesBurned = random.Next(150, 601), // 150 to 600 calories
                Intensity = random.Next(4, 10),       // Scale of 4-9
                Fatigue = random.Next(3, 9),          // Scale of 3-8
                Date = workoutDate,
                Notes = i % 10 == 0 ? "Felt particularly good today!" : null // Add a note every 10th workout
            });
        }

        context.Workouts.AddRange(workouts);
        await context.SaveChangesAsync();
    }

    private static string GetRandomExerciseType(Random random)
    {
        string[] types = { "Cardio", "Strength", "Flexibility" };
        return types[random.Next(types.Length)];
    }
}