using Microsoft.EntityFrameworkCore;

namespace PointFlow.Model;

public class PointFlowDbContext : DbContext
{
    public PointFlowDbContext(DbContextOptions<PointFlowDbContext> options) 
        : base(options)
    {
    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PointTask> Tasks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PomodoroSession> PomodoroSessions { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Reward> Rewards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var pointTaskTags = modelBuilder
            .Entity<PointTask>()
            .HasMany(pt => pt.Tags)
            .WithMany(t => t.Tasks)
            .UsingEntity<Dictionary<string, object>>("PointTaskTags");

        // Configure N-N relationship: PointTask <-> Tag
        pointTaskTags.HasData(
            new { TagsId = 1, TasksId = 1 },
            new { TagsId = 3, TasksId = 2 },
            new { TagsId = 1, TasksId = 3 },
            new { TagsId = 4, TasksId = 3 },
            new { TagsId = 2, TasksId = 4 },
            new { TagsId = 3, TasksId = 5 },
            new { TagsId = 1, TasksId = 6 },
            new { TagsId = 2, TasksId = 6 });

        // Foreign key constraints configuration
        modelBuilder
            .Entity<PointTask>()
            .HasOne(pt => pt.AppUser)
            .WithMany(u => u.Tasks)
            .HasForeignKey(pt => pt.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<PointTask>()
            .HasOne(pt => pt.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(pt => pt.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<PomodoroSession>()
            .HasOne(ps => ps.PointTask)
            .WithMany(pt => pt.PomodoroSessions)
            .HasForeignKey(ps => ps.PointTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<Quiz>()
            .HasOne(q => q.PomodoroSession)
            .WithMany(ps => ps.Quizzes)
            .HasForeignKey(q => q.PomodoroSessionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<Reward>()
            .HasOne(r => r.AppUser)
            .WithMany(u => u.Rewards)
            .HasForeignKey(r => r.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = 1,
                Username = "ana_k",
                Email = "ana@example.com",
                TotalPointsEarned = 320,
                CurrentBalance = 150,
                CreatedAt = new DateTime(2025, 9, 1)
            },
            new AppUser
            {
                Id = 2,
                Username = "marko_p",
                Email = "marko@example.com",
                TotalPointsEarned = 200,
                CurrentBalance = 80,
                CreatedAt = new DateTime(2025, 11, 15)
            },
            new AppUser
            {
                Id = 3,
                Username = "petra_v",
                Email = "petra@example.com",
                TotalPointsEarned = 510,
                CurrentBalance = 260,
                CreatedAt = new DateTime(2025, 6, 1)
            });

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Learning", Description = "Tasks related to acquiring new knowledge" },
            new Category { Id = 2, Name = "Fitness", Description = "Tasks related to physical health and exercise" },
            new Category { Id = 3, Name = "Work", Description = "Professional and career-related tasks" });

        modelBuilder.Entity<Tag>().HasData(
            new Tag { Id = 1, Name = "Study" },
            new Tag { Id = 2, Name = "Work" },
            new Tag { Id = 3, Name = "Health" },
            new Tag { Id = 4, Name = "Personal" });

        modelBuilder.Entity<PointTask>().HasData(
            new PointTask
            {
                Id = 1,
                Title = "Study C# fundamentals",
                Description = "Go through chapters 1-5 of the C# guide",
                PointsReward = 50,
                IsCompleted = true,
                Priority = TaskPriority.High,
                CreatedAt = new DateTime(2026, 3, 1),
                AppUserId = 1,
                CategoryId = 1
            },
            new PointTask
            {
                Id = 2,
                Title = "Run 5km",
                Description = "Morning run in the park",
                PointsReward = 30,
                IsCompleted = true,
                Priority = TaskPriority.Medium,
                CreatedAt = new DateTime(2026, 3, 3),
                AppUserId = 1,
                CategoryId = 2
            },
            new PointTask
            {
                Id = 3,
                Title = "Read Clean Code book",
                Description = "At least 30 pages per session",
                PointsReward = 40,
                IsCompleted = false,
                Priority = TaskPriority.Low,
                CreatedAt = new DateTime(2026, 3, 10),
                AppUserId = 1,
                CategoryId = 1
            },
            new PointTask
            {
                Id = 4,
                Title = "Finish quarterly report",
                Description = "Compile Q1 data and write summary",
                PointsReward = 60,
                IsCompleted = false,
                Priority = TaskPriority.High,
                CreatedAt = new DateTime(2026, 3, 20),
                AppUserId = 2,
                CategoryId = 3
            },
            new PointTask
            {
                Id = 5,
                Title = "Gym session",
                Description = "Upper body workout",
                PointsReward = 25,
                IsCompleted = true,
                Priority = TaskPriority.Medium,
                CreatedAt = new DateTime(2026, 3, 22),
                AppUserId = 2,
                CategoryId = 2
            },
            new PointTask
            {
                Id = 6,
                Title = "Study SOLID principles",
                Description = "Deep dive into object-oriented design principles",
                PointsReward = 70,
                IsCompleted = true,
                Priority = TaskPriority.High,
                CreatedAt = new DateTime(2026, 3, 15),
                AppUserId = 3,
                CategoryId = 1
            });

        modelBuilder.Entity<Reward>().HasData(
            new Reward
            {
                Id = 1,
                Name = "Netflix evening",
                Description = "1 hour of guilt-free Netflix",
                PointsCost = 50,
                IsLocked = false,
                UnlockedAt = new DateTime(2026, 3, 5),
                AppUserId = 1
            },
            new Reward
            {
                Id = 2,
                Name = "Buy a new book",
                Description = "Treat yourself to a new technical book",
                PointsCost = 120,
                IsLocked = true,
                UnlockedAt = new DateTime(2026, 3, 1),
                AppUserId = 1
            },
            new Reward
            {
                Id = 3,
                Name = "Gaming session",
                Description = "2 hours of gaming without guilt",
                PointsCost = 60,
                IsLocked = false,
                UnlockedAt = new DateTime(2026, 3, 23),
                AppUserId = 2
            },
            new Reward
            {
                Id = 4,
                Name = "Weekend trip",
                Description = "Short trip to the mountains",
                PointsCost = 300,
                IsLocked = true,
                UnlockedAt = new DateTime(2026, 3, 1),
                AppUserId = 2
            },
            new Reward
            {
                Id = 5,
                Name = "Spa day",
                Description = "Full relaxation day at the spa",
                PointsCost = 200,
                IsLocked = false,
                UnlockedAt = new DateTime(2026, 3, 20),
                AppUserId = 3
            },
            new Reward
            {
                Id = 6,
                Name = "Online course",
                Description = "Enroll in an advanced .NET course",
                PointsCost = 150,
                IsLocked = false,
                UnlockedAt = new DateTime(2026, 3, 27),
                AppUserId = 3
            });

        modelBuilder.Entity<PomodoroSession>().HasData(
            new PomodoroSession
            {
                Id = 1,
                StartTime = new DateTime(2026, 3, 1, 9, 0, 0),
                EndTime = new DateTime(2026, 3, 1, 9, 25, 0),
                DurationMinutes = 25,
                LearnedNotes = "Covered C# type system: value types vs reference types, boxing/unboxing.",
                IsQuizPassed = true,
                PointTaskId = 1
            },
            new PomodoroSession
            {
                Id = 2,
                StartTime = new DateTime(2026, 3, 15, 10, 0, 0),
                EndTime = new DateTime(2026, 3, 15, 10, 25, 0),
                DurationMinutes = 25,
                LearnedNotes = "Studied SOLID principles with examples in C#.",
                IsQuizPassed = true,
                PointTaskId = 6
            });

        modelBuilder.Entity<Quiz>().HasData(
            new Quiz
            {
                Id = 1,
                Question = "What is the difference between a class and a struct in C#?",
                ExpectedAnswer = "A class is a reference type allocated on the heap; a struct is a value type allocated on the stack.",
                UserAnswer = "Classes are reference types, structs are value types stored on the stack.",
                PomodoroSessionId = 1
            },
            new Quiz
            {
                Id = 2,
                Question = "What does SOLID stand for?",
                ExpectedAnswer = "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion.",
                UserAnswer = "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion.",
                PomodoroSessionId = 2
            });
    }
}
