using Microsoft.EntityFrameworkCore;

namespace WeightTracker.Data;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<User> CreateAsync(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<User> ReadUser(int userId)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (user is null)
        {
            throw new ArgumentException($"No user found for id = {userId}");
        }
        return user;
    }

    public async Task<IEnumerable<User>> ReadeUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<User> UpdateAsync(User user)
    {
        _db.Entry(user).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = new User { UserId = id };
        _db.Attach(user);
        _db.Users.Remove(user);
        return await _db.SaveChangesAsync() > 0;
    }
}