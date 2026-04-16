using Microsoft.AspNetCore.Mvc;
using PointFlow.Web.Repositories;

namespace PointFlow.Web.Controllers;

public class TagController : Controller
{
    private readonly TagMockRepository _tagRepository;
    private readonly PointTaskMockRepository _taskRepository;

    public TagController(TagMockRepository tagRepository, PointTaskMockRepository taskRepository)
    {
        _tagRepository = tagRepository;
        _taskRepository = taskRepository;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Tagovi", null) };
        var tags = _tagRepository.GetAll();
        return View(tags);
    }

    public IActionResult Details(int id)
    {
        var tag = _tagRepository.GetById(id);
        if (tag is null)
            return NotFound();

        // Since mock tasks don't have Tags collections populated,
        // we use a known mapping based on Program.cs data
        var tagTaskMap = new Dictionary<int, List<int>>
        {
            { 1, [1, 3, 6, 7, 8] }, // Study
            { 2, [4, 6, 8] },        // Work
            { 3, [2, 5, 9] },        // Health
            { 4, [3, 5, 9] }         // Personal
        };

        if (tagTaskMap.TryGetValue(id, out var taskIds))
        {
            tag.Tasks = _taskRepository.GetAll()
                .Where(t => taskIds.Contains(t.Id))
                .ToList();
        }

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Tagovi", "/Tag"), ("#" + tag.Name, null) };
        return View(tag);
    }
}
