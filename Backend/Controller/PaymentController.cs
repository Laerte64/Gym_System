using Data;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controller;

[Route("api/payment")]
[ApiController]
internal class UserController : ControllerBase
{
    private readonly GymContext _context;
    public UserController(GymContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();
        return Created("", user);
    }

    [HttpPut]
    public async Task<IActionResult> Update(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return NoContent();
        _context.Remove(user);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
