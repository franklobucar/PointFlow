using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointFlow.Model;

public class Reward
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public int PointsCost { get; set; }
    public bool IsLocked { get; set; }
    public DateTime UnlockedAt { get; set; }

    // 1-N: AppUser -> Reward
    [ForeignKey(nameof(AppUser))]
    public int AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; } = null!;
}
