using PointFlow.Model;

namespace PointFlow.Web.Repositories;

public class AppUserMockRepository
{
    private readonly List<AppUser> _users =
    [
        new AppUser
        {
            Id = 1,
            Username = "ana_k",
            Email = "ana@example.com",
            TotalPointsEarned = 320,
            CurrentBalance = 150,
            CreatedAt = new DateTime(2025, 9, 1),
            Tasks =
            [
                new PointTask { Id = 1, Title = "Study C# fundamentals",    PointsReward = 50, IsCompleted = true,  Priority = TaskPriority.High,   CreatedAt = new DateTime(2026, 3,  1) },
                new PointTask { Id = 2, Title = "Run 5km",                   PointsReward = 30, IsCompleted = true,  Priority = TaskPriority.Medium, CreatedAt = new DateTime(2026, 3,  3) },
                new PointTask { Id = 3, Title = "Read Clean Code book",      PointsReward = 40, IsCompleted = false, Priority = TaskPriority.Low,    CreatedAt = new DateTime(2026, 3, 10) }
            ]
        },
        new AppUser
        {
            Id = 2,
            Username = "marko_p",
            Email = "marko@example.com",
            TotalPointsEarned = 200,
            CurrentBalance = 80,
            CreatedAt = new DateTime(2025, 11, 15),
            Tasks =
            [
                new PointTask { Id = 4, Title = "Finish quarterly report", PointsReward = 60, IsCompleted = false, Priority = TaskPriority.High,   CreatedAt = new DateTime(2026, 3, 20) },
                new PointTask { Id = 5, Title = "Gym session",             PointsReward = 25, IsCompleted = true,  Priority = TaskPriority.Medium, CreatedAt = new DateTime(2026, 3, 22) }
            ]
        },
        new AppUser
        {
            Id = 3,
            Username = "petra_v",
            Email = "petra@example.com",
            TotalPointsEarned = 510,
            CurrentBalance = 260,
            CreatedAt = new DateTime(2025, 6, 1),
            Tasks =
            [
                new PointTask { Id = 6, Title = "Study SOLID principles", PointsReward = 70, IsCompleted = true, Priority = TaskPriority.High, CreatedAt = new DateTime(2026, 3, 15) }
            ]
        }
    ];

    public List<AppUser> GetAll() => _users;

    public AppUser? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
}
