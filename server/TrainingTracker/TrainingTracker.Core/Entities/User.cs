﻿namespace TrainingTracker.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}