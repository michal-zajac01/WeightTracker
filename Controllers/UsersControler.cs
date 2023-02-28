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
}