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
        var users = _userRepository.GetAll();
        return View(users);
    }

    public IActionResult Details(int id)
    {
        var user = _userRepository.GetById(id);
        if (user is null)
            return NotFound();

        return View(user);
    }
}
