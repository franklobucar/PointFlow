namespace PointFlow.Model;

public class Reward
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PointsCost { get; set; }
    public bool IsLocked { get; set; }
    public DateTime UnlockedAt { get; set; }

    // 1-N: AppUser -> Reward
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
}
