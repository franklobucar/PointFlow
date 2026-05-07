using Microsoft.AspNetCore.Mvc;
using PointFlow.Model;
using PointFlow.Web.Repositories;

namespace PointFlow.Web.Controllers;

public class QuizController : Controller
{
    private readonly IQuizRepository _quizRepository;

    public QuizController(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Kvizovi", null) };
        var quizzes = await _quizRepository.GetAllAsync();
        return View(quizzes);
    }

    public async Task<IActionResult> Details(int id)
    {
        var quiz = await _quizRepository.GetByIdAsync(id);
        if (quiz is null)
        {
            return NotFound();
        }

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Kvizovi", "/quizzes"), ($"Kviz #{quiz.Id}", null) };
        return View(quiz);
    }

    public async Task<IActionResult> Create()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[]
        {
            ("Kvizovi", "/quizzes"),
            ("Novi kviz", null)
        };

        await PopulatePomodoroSessionsAsync();
        return View(new Quiz());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Quiz quiz)
    {
        if (!ModelState.IsValid)
        {
            await PopulatePomodoroSessionsAsync();
            return View(quiz);
        }

        await _quizRepository.AddAsync(quiz);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var quiz = await _quizRepository.GetByIdAsync(id);
        if (quiz is null)
        {
            return NotFound();
        }

        ViewData["Breadcrumb"] = new (string Label, string? Url)[]
        {
            ("Kvizovi", "/quizzes"),
            ($"Uredi kviz #{quiz.Id}", null)
        };

        await PopulatePomodoroSessionsAsync();
        return View(quiz);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Quiz quiz)
    {
        if (id != quiz.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            await PopulatePomodoroSessionsAsync();
            return View(quiz);
        }

        await _quizRepository.UpdateAsync(quiz);
        return RedirectToAction(nameof(Details), new { id = quiz.Id });
    }

    private async Task PopulatePomodoroSessionsAsync()
    {
        var sessions = await _quizRepository.GetPomodoroSessionsAsync();
        ViewBag.PomodoroSessions = sessions;
    }
}
