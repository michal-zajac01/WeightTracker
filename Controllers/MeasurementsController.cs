using Microsoft.AspNetCore.Mvc;
using WeightTracker.Data;

namespace WeightTracker.Controllers;

public class MeasurementsController : Controller
{
    private readonly IMeasurementRepository _repo;

    public MeasurementsController(IMeasurementRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] int id, [FromForm] int userId)
    {
        await _repo.DeleteAsync(id);
        return RedirectToAction("Details", "Users", new { id = userId });
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("UserId", "TakenOn", "Value")] Measurement measurement)
    {
        await _repo.CreateAsync(measurement);
        return RedirectToAction("Details", "Users", new { id = measurement.UserId });
    }
}