using PointFlow.Model;

namespace PointFlow.Web.Repositories;

public class PomodoroSessionMockRepository
{
    private readonly List<PomodoroSession> _sessions;

    public PomodoroSessionMockRepository()
    {
        var quiz1 = new Quiz
        {
            Id = 1,
            Question = "What is the difference between a class and a struct in C#?",
            ExpectedAnswer = "A class is a reference type allocated on the heap; a struct is a value type allocated on the stack.",
            UserAnswer = "Classes are reference types, structs are value types stored on the stack.",
            PomodoroSessionId = 1
        };

        var quiz2 = new Quiz
        {
            Id = 2,
            Question = "What does SOLID stand for?",
            ExpectedAnswer = "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion.",
            UserAnswer = "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion.",
            PomodoroSessionId = 2
        };

        var session1 = new PomodoroSession
        {
            Id = 1,
            StartTime = new DateTime(2026, 3, 1, 9, 0, 0),
            EndTime = new DateTime(2026, 3, 1, 9, 25, 0),
            DurationMinutes = 25,
            LearnedNotes = "Covered C# type system: value types vs reference types, boxing/unboxing.",
            IsQuizPassed = true,
            PointTaskId = 1,
            Quizzes = [quiz1]
        };
        quiz1.PomodoroSession = session1;

        var session2 = new PomodoroSession
        {
            Id = 2,
            StartTime = new DateTime(2026, 3, 15, 10, 0, 0),
            EndTime = new DateTime(2026, 3, 15, 10, 25, 0),
            DurationMinutes = 25,
            LearnedNotes = "Studied SOLID principles with examples in C#.",
            IsQuizPassed = true,
            PointTaskId = 7,
            Quizzes = [quiz2]
        };
        quiz2.PomodoroSession = session2;

        _sessions = [session1, session2];
    }

    public List<PomodoroSession> GetAll() => _sessions;

    public PomodoroSession? GetById(int id) => _sessions.FirstOrDefault(s => s.Id == id);
}
