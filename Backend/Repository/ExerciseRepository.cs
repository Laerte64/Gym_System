namespace Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Model;

class ExerciseRepository : IRepository<Exercise>
{
    private readonly GymContext _context;

    public ExerciseRepository(GymContext context)
    {
        _context = context;
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await _context.Exercises.FindAsync(id);
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await _context.Exercises.ToListAsync();
    }

    public async Task AddAsync(Exercise entity)
    {
        await _context.Exercises.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Exercise entity)
    {
        _context.Exercises.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Exercise entity)
    {
        _context.Exercises.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
