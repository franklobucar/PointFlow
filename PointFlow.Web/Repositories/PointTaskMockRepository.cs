using PointFlow.Model;

namespace PointFlow.Web.Repositories;

public class PointTaskMockRepository
{
    private readonly List<PointTask> _tasks =
    [
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
            AppUser = new AppUser { Id = 1, Username = "ana_k", Email = "ana@example.com" },
            CategoryId = 1,
            Category = new Category { Id = 1, Name = "Learning" }
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
            AppUser = new AppUser { Id = 1, Username = "ana_k", Email = "ana@example.com" },
            CategoryId = 2,
            Category = new Category { Id = 2, Name = "Fitness" }
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
            AppUser = new AppUser { Id = 1, Username = "ana_k", Email = "ana@example.com" },
            CategoryId = 1,
            Category = new Category { Id = 1, Name = "Learning" }
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
            AppUser = new AppUser { Id = 2, Username = "marko_p", Email = "marko@example.com" },
            CategoryId = 3,
            Category = new Category { Id = 3, Name = "Work" }
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
            AppUser = new AppUser { Id = 2, Username = "marko_p", Email = "marko@example.com" },
            CategoryId = 2,
            Category = new Category { Id = 2, Name = "Fitness" }
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
            AppUser = new AppUser { Id = 3, Username = "petra_v", Email = "petra@example.com" },
            CategoryId = 1,
            Category = new Category { Id = 1, Name = "Learning" }
        }
    ];

    public List<PointTask> GetAll() => _tasks;

    public PointTask? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);
}
