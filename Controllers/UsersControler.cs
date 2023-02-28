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
        return View(await _userRepository.ReadUsers());
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
    
    public async Task<IActionResult> Edit(int id)
    {
        var user = await _userRepository.ReadUser(id);
        return View(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
        await _userRepository.UpdateAsync(user);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userRepository.ReadUser(id);
        return View(user);
    }

    public async Task<IActionResult> ConfirmDeletion(int id)
    {
        await _userRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}