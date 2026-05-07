using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointFlow.Model;

public class Quiz
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(500)]
    public string Question { get; set; } = string.Empty;

    [Required]
    [MaxLength(1000)]
    public string ExpectedAnswer { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string UserAnswer { get; set; } = string.Empty;

    // 1-N: PomodoroSession -> Quiz
    [ForeignKey(nameof(PomodoroSession))]
    public int PomodoroSessionId { get; set; }
    public virtual PomodoroSession PomodoroSession { get; set; } = null!;
}
