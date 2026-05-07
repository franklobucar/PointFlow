using Microsoft.EntityFrameworkCore;
using PointFlow.Model;

namespace PointFlow.Web.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly PointFlowDbContext _dbContext;

    public QuizRepository(PointFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Quiz>> GetAllAsync()
    {
        return _dbContext.Quizzes
            .Include(q => q.PomodoroSession)
            .OrderBy(q => q.Id)
            .ToListAsync();
    }

    public Task<Quiz?> GetByIdAsync(int id)
    {
        return _dbContext.Quizzes
            .Include(q => q.PomodoroSession)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public Task<List<PomodoroSession>> GetPomodoroSessionsAsync()
    {
        return _dbContext.PomodoroSessions
            .OrderByDescending(s => s.StartTime)
            .ToListAsync();
    }

    public async Task AddAsync(Quiz quiz)
    {
        _dbContext.Quizzes.Add(quiz);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Quiz quiz)
    {
        _dbContext.Quizzes.Update(quiz);
        await _dbContext.SaveChangesAsync();
    }
}
