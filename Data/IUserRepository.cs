namespace WeightTracker.Data;

public interface IUserRepository
{
    public Task<User> CreateAsync(User user);
    public Task<User> ReadUser(int userId);
    public Task<IEnumerable<User>> ReadeUsers();
    public Task<User> UpdateAsync(User user);
    public Task<bool> DeleteAsync(int id);
}