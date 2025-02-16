namespace Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Model;

class SplitRepository : IRepository<Split>
{
    private readonly GymContext _context;

    public SplitRepository(GymContext context)
    {
        _context = context;
    }

    public async Task<Split?> GetByIdAsync(int id)
    {
        return await _context.Splits.FindAsync(id);
    }

    public async Task<IEnumerable<Split>> GetAllAsync()
    {
        return await _context.Splits.ToListAsync();
    }

    public async Task AddAsync(Split entity)
    {
        await _context.Splits.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Split entity)
    {
        _context.Splits.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Split entity)
    {
        _context.Splits.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
