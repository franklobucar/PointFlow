namespace PointFlow.Model;

public class PomodoroSession
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string LearnedNotes { get; set; } = string.Empty;
    public bool IsQuizPassed { get; set; }
    public int DurationMinutes { get; set; }

    // 1-N: PointTask -> PomodoroSession
    public int PointTaskId { get; set; }
    public PointTask PointTask { get; set; } = null!;

    // 1-N: PomodoroSession -> Quiz
    public List<Quiz> Quizzes { get; set; } = [];
}
