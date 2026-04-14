using PointFlow.Model;

namespace PointFlow.Web.Repositories;

public class RewardMockRepository
{
    private readonly List<Reward> _rewards =
    [
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
        }
    ];

    public List<Reward> GetAll() => _rewards;

    public Reward? GetById(int id) => _rewards.FirstOrDefault(r => r.Id == id);
}
