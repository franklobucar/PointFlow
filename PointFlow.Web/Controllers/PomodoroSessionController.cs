using Microsoft.AspNetCore.Mvc;
using PointFlow.Web.Repositories;

namespace PointFlow.Web.Controllers;

public class PomodoroSessionController : Controller
{
    private readonly PomodoroSessionMockRepository _sessionRepository;

    public PomodoroSessionController(PomodoroSessionMockRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Pomodoro", null) };
        var sessions = _sessionRepository.GetAll();
        return View(sessions);
    }

    public IActionResult Details(int id)
    {
        var session = _sessionRepository.GetById(id);
        if (session is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Pomodoro", "/PomodoroSession"), ($"Sesija #{session.Id}", null) };
        return View(session);
    }
}
