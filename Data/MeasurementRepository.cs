using Microsoft.EntityFrameworkCore;

namespace WeightTracker.Data;

public class MeasurementRepository : IMeasurementRepository
{
    private readonly AppDbContext _db;

    public MeasurementRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Measurement> CreateAsync(Measurement measurement)
    {
        _db.Mesurements.Add(measurement);
        await _db.SaveChangesAsync();
        return measurement;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Measurement measurement = new() { MeasurementId = id };
        _db.Mesurements.Attach(measurement);
        _db.Mesurements.Remove(measurement);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<IList<Measurement>> ReadMeasurementsOfUser(int userId)
    {
        var measurements = await _db.Mesurements
            .Where(m => m.UserId == userId)
            .OrderBy(m => m.TakenOn)
            .ToListAsync();
        return measurements;
    }
}