using Microsoft.AspNetCore.Mvc;
using PointFlow.Web.Repositories;

namespace PointFlow.Web.Controllers;

public class TaskController : Controller
{
    private readonly PointTaskMockRepository _taskRepository;

    public TaskController(PointTaskMockRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Taskovi", null) };
        var tasks = _taskRepository.GetAll();
        return View(tasks);
    }

    public IActionResult Details(int id)
    {
        var task = _taskRepository.GetById(id);
        if (task is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Taskovi", "/Task"), (task.Title, null) };
        return View(task);
    }
}
