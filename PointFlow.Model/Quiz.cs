namespace PointFlow.Model;

public class Quiz
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public string ExpectedAnswer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;

    // 1-N: PomodoroSession -> Quiz
    public int PomodoroSessionId { get; set; }
    public PomodoroSession PomodoroSession { get; set; } = null!;
}
