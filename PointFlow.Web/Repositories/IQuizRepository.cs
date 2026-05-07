using PointFlow.Model;

namespace PointFlow.Web.Repositories;

public interface IQuizRepository
{
    Task<List<Quiz>> GetAllAsync();
    Task<Quiz?> GetByIdAsync(int id);
    Task<List<PomodoroSession>> GetPomodoroSessionsAsync();
    Task AddAsync(Quiz quiz);
    Task UpdateAsync(Quiz quiz);
}
