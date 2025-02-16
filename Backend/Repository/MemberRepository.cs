namespace Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Model;

class MemberRepository : IRepository<Member>
{
    private readonly GymContext _context;

    public MemberRepository(GymContext context)
    {
        _context = context;
    }

    public async Task<Member?> GetByIdAsync(int id)
    {
        return await _context.Members.FindAsync(id);
    }

    public async Task<IEnumerable<Member>> GetAllAsync()
    {
        return await _context.Members.ToListAsync();
    }

    public async Task AddAsync(Member entity)
    {
        await _context.Members.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Member entity)
    {
        _context.Members.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Member entity)
    {
        _context.Members.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
