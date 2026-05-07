using System.ComponentModel.DataAnnotations;

namespace PointFlow.Model;

public class AppUser
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public int TotalPointsEarned { get; set; }
    public int CurrentBalance { get; set; }
    public DateTime CreatedAt { get; set; }

    // 1-N: AppUser -> PointTask
    public virtual ICollection<PointTask> Tasks { get; set; } = new List<PointTask>();

    // 1-N: AppUser -> Reward
    public virtual ICollection<Reward> Rewards { get; set; } = new List<Reward>();
}
