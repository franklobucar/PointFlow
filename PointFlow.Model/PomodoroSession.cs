using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointFlow.Model;

public class PomodoroSession
{
    [Key]
    public int Id { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    [MaxLength(2000)]
    public string LearnedNotes { get; set; } = string.Empty;

    public bool IsQuizPassed { get; set; }
    public int DurationMinutes { get; set; }

    // 1-N: PointTask -> PomodoroSession
    [ForeignKey(nameof(PointTask))]
    public int PointTaskId { get; set; }
    public virtual PointTask PointTask { get; set; } = null!;

    // 1-N: PomodoroSession -> Quiz
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
