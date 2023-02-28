namespace WeightTracker.Data;

public interface IMeasurementRepository
{
    Task<Measurement> CreateAsync(Measurement measurement);
    Task<bool> DeleteAsync(int id);
    Task<IList<Measurement>> ReadMeasurementsOfUser(int userId);
}