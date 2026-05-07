using Microsoft.AspNetCore.Mvc;
using PointFlow.Model;

namespace PointFlow.Web.Controllers;

public class RewardController : Controller
{
    private readonly PointFlowDbContext _dbContext;

    public RewardController(PointFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Nagrade", null) };
        var rewards = _dbContext.Rewards.ToList();
        return View(rewards);
    }

    public IActionResult Details(int id)
    {
        var reward = _dbContext.Rewards.FirstOrDefault(r => r.Id == id);
        if (reward is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Nagrade", "/Reward"), (reward.Name, null) };
        return View(reward);
    }
}
