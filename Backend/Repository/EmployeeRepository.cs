namespace Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Model;

class EmployeeRepository : IRepository<Employee>
{
    private readonly GymContext _context;

    public EmployeeRepository(GymContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task AddAsync(Employee entity)
    {
        await _context.Employees.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee entity)
    {
        _context.Employees.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Employee entity)
    {
        _context.Employees.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
