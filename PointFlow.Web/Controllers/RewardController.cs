using Microsoft.AspNetCore.Mvc;
using PointFlow.Web.Repositories;

namespace PointFlow.Web.Controllers;

public class RewardController : Controller
{
    private readonly RewardMockRepository _rewardRepository;

    public RewardController(RewardMockRepository rewardRepository)
    {
        _rewardRepository = rewardRepository;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Nagrade", null) };
        var rewards = _rewardRepository.GetAll();
        return View(rewards);
    }

    public IActionResult Details(int id)
    {
        var reward = _rewardRepository.GetById(id);
        if (reward is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Nagrade", "/Reward"), (reward.Name, null) };
        return View(reward);
    }
}
