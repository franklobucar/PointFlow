namespace PointFlow.Model;

public class AppUser
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int TotalPointsEarned { get; set; }
    public int CurrentBalance { get; set; }
    public DateTime CreatedAt { get; set; }

    // 1-N: AppUser -> PointTask
    public List<PointTask> Tasks { get; set; } = [];

    // 1-N: AppUser -> Reward
    public List<Reward> Rewards { get; set; } = [];
}
