using Microsoft.AspNetCore.Mvc;
using PointFlow.Web.Repositories;

namespace PointFlow.Web.Controllers;

public class CategoryController : Controller
{
    private readonly CategoryMockRepository _categoryRepository;
    private readonly PointTaskMockRepository _taskRepository;

    public CategoryController(CategoryMockRepository categoryRepository, PointTaskMockRepository taskRepository)
    {
        _categoryRepository = categoryRepository;
        _taskRepository = taskRepository;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Kategorije", null) };
        var categories = _categoryRepository.GetAll();
        return View(categories);
    }

    public IActionResult Details(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category is null)
            return NotFound();

        category.Tasks = _taskRepository.GetAll()
            .Where(t => t.CategoryId == id)
            .ToList();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Kategorije", "/Category"), (category.Name, null) };
        return View(category);
    }
}
