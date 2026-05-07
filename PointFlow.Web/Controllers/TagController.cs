using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointFlow.Model;

namespace PointFlow.Web.Controllers;

public class TagController : Controller
{
    private readonly PointFlowDbContext _dbContext;

    public TagController(PointFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Tagovi", null) };
        var tags = _dbContext.Tags.ToList();
        return View(tags);
    }

    public IActionResult Details(int id)
    {
        var tag = _dbContext.Tags
            .Include(t => t.Tasks)
            .FirstOrDefault(t => t.Id == id);
        if (tag is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Tagovi", "/Tag"), ("#" + tag.Name, null) };
        return View(tag);
    }
}
