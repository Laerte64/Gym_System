namespace Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Model;

public class WorkoutDayRepository : IRepository<WorkoutDay>
{
    private readonly GymContext _context;

    public WorkoutDayRepository(GymContext context)
    {
        _context = context;
    }

    public async Task<WorkoutDay?> GetByIdAsync(int id)
    {
        return await _context.WorkoutDays.FindAsync(id);
    }

    public async Task<IEnumerable<WorkoutDay>> GetAllAsync()
    {
        return await _context.WorkoutDays.ToListAsync();
    }

    public async Task AddAsync(WorkoutDay entity)
    {
        await _context.WorkoutDays.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(WorkoutDay entity)
    {
        _context.WorkoutDays.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(WorkoutDay entity)
    {
        _context.WorkoutDays.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
