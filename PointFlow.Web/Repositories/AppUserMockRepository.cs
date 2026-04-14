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
        }
    ];

    public List<AppUser> GetAll() => _users;

    public AppUser? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
}
