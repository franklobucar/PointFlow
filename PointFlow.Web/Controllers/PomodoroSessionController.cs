using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointFlow.Model;

namespace PointFlow.Web.Controllers;

public class PomodoroSessionController : Controller
{
    private readonly PointFlowDbContext _dbContext;

    public PomodoroSessionController(PointFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Pomodoro", null) };
        var sessions = _dbContext.PomodoroSessions.ToList();
        return View(sessions);
    }

    public IActionResult Details(int id)
    {
        var session = _dbContext.PomodoroSessions
            .Include(s => s.Quizzes)
            .FirstOrDefault(s => s.Id == id);
        if (session is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Pomodoro", "/PomodoroSession"), ($"Sesija #{session.Id}", null) };
        return View(session);
    }
}
