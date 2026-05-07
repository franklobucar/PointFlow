using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointFlow.Model;

namespace PointFlow.Web.Controllers;

public class CategoryController : Controller
{
    private readonly PointFlowDbContext _dbContext;

    public CategoryController(PointFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Kategorije", null) };
        var categories = _dbContext.Categories.ToList();
        return View(categories);
    }

    public IActionResult Details(int id)
    {
        var category = _dbContext.Categories
            .Include(c => c.Tasks)
            .FirstOrDefault(c => c.Id == id);

        if (category is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Kategorije", "/Category"), (category.Name, null) };
        return View(category);
    }
}
