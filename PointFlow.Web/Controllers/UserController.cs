using Microsoft.AspNetCore.Mvc;
using PointFlow.Web.Repositories;

namespace PointFlow.Web.Controllers;

public class UserController : Controller
{
    private readonly AppUserMockRepository _userRepository;

    public UserController(AppUserMockRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Korisnici", null) };
        var users = _userRepository.GetAll();
        return View(users);
    }

    public IActionResult Details(int id)
    {
        var user = _userRepository.GetById(id);
        if (user is null)
            return NotFound();

        ViewData["Breadcrumb"] = new (string Label, string? Url)[] { ("Korisnici", "/User"), (user.Username, null) };
        return View(user);
    }
}
