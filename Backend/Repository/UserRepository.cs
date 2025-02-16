namespace Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Model;

public class UserRepository : Interface.IRepository<User>
{
    private readonly GymContext _context;

    public UserRepository(GymContext context)
    {
        _context = context;
    }

    public async Task<User?> AuthenticateAsync(string login, string password)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(User entity)
    {
        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }
}


