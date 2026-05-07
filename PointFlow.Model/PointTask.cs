using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointFlow.Model;

public class PointTask
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public int PointsReward { get; set; }
    public bool IsCompleted { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime CreatedAt { get; set; }

    // 1-N: AppUser -> PointTask
    [ForeignKey(nameof(AppUser))]
    public int AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; } = null!;

    // 1-N: Category -> PointTask
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;

    // N-N: PointTask <-> Tag
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    // 1-N: PointTask -> PomodoroSession
    public virtual ICollection<PomodoroSession> PomodoroSessions { get; set; } = new List<PomodoroSession>();
}
