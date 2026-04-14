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
        }
    ];

    public List<PointTask> GetAll() => _tasks;

    public PointTask? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);
}
