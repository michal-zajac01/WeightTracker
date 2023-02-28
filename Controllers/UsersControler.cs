using Microsoft.AspNetCore.Mvc;
using WeightTracker.Data;

namespace WeightTracker.Controllers;

public class UsersController : Controller
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _userRepository.ReadeUsers());
    }

    public async Task<IActionResult> Details(int id)
    {
        var user = await _userRepository.ReadUser(id);
        return View(user);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("FirstName", "LastName")] User user)
    {
        await _userRepository.CreateAsync(user);
        return RedirectToAction(nameof(Index));
    }
}