using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointFlow.Model;

namespace PointFlow.Web.Controllers;

public class TaskController : Controller
{
    private readonly PointFlowDbContext _dbContext;

    public TaskController(PointFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Taskovi", null) };
        var tasks = _dbContext.Tasks.ToList();
        return View(tasks);
    }

    public IActionResult Details(int id)
    {
        var task = _dbContext.Tasks
            .Include(t => t.AppUser)
            .Include(t => t.Category)
            .FirstOrDefault(t => t.Id == id);

        if (task is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Taskovi", "/Task"), (task.Title, null) };
        return View(task);
    }
}
