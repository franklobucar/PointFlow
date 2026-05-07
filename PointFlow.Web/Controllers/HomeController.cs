using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PointFlow.Model;
using PointFlow.Web.Models;

namespace PointFlow.Web.Controllers;

public class HomeController : Controller
{
    private readonly PointFlowDbContext _dbContext;

    public HomeController(PointFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var vm = new DashboardViewModel
        {
            Users   = _dbContext.Users.ToList(),
            Tasks   = _dbContext.Tasks.ToList(),
            Rewards = _dbContext.Rewards.ToList()
        };
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
