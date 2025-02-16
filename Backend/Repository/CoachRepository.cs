namespace Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Model;

public class CoachRepository : Interface.IRepository<Coach>
{
    private readonly GymContext _context;

    public CoachRepository(GymContext context)
    {
        _context = context;
    }

    public async Task<Coach?> GetByIdAsync(int id)
    {
        return await _context.Coaches.FindAsync(id);
    }

    public async Task<IEnumerable<Coach>> GetAllAsync()
    {
        return await _context.Coaches.ToListAsync();
    }

    public async Task AddAsync(Coach entity)
    {
        await _context.Coaches.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Coach entity)
    {
        _context.Coaches.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Coach entity)
    {
        _context.Coaches.Remove(entity);
        await _context.SaveChangesAsync();
    }
}


