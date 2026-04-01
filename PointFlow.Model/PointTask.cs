namespace PointFlow.Model;

public class PointTask
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PointsReward { get; set; }
    public bool IsCompleted { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime CreatedAt { get; set; }

    // 1-N: AppUser -> PointTask
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    // 1-N: Category -> PointTask
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    // N-N: PointTask <-> Tag
    public List<Tag> Tags { get; set; } = [];

    // 1-N: PointTask -> PomodoroSession
    public List<PomodoroSession> PomodoroSessions { get; set; } = [];
}
