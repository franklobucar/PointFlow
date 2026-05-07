using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointFlow.Model;

namespace PointFlow.Web.Controllers;

public class UserController : Controller
{
    private readonly PointFlowDbContext _dbContext;

    public UserController(PointFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Korisnici", null) };
        var users = _dbContext.Users.ToList();
        return View(users);
    }

    public IActionResult Details(int id)
    {
        var user = _dbContext.Users
            .Include(u => u.Tasks)
            .Include(u => u.Rewards)
            .FirstOrDefault(u => u.Id == id);
        if (user is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Korisnici", "/User"), (user.Username, null) };
        return View(user);
    }
}
