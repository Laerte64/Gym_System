using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Controller;

[Route("api/coach")]
[ApiController]
[Authorize] // Require authentication for all endpoints
public class CoachController : ControllerBase
{
    private readonly CoachRepository _coachRepository;

    public CoachController(CoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var coaches = await _coachRepository.GetAllAsync();
        return Ok(coaches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var coach = await _coachRepository.GetByIdAsync(id);
        if (coach == null)
            return NotFound();
        
        return Ok(coach);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Coach coach)
    {
        await _coachRepository.AddAsync(coach);
        return CreatedAtAction(nameof(GetById), new { id = coach.Id }, coach);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Coach coach)
    {
        if (id != coach.Id)
            return BadRequest("ID mismatch");

        await _coachRepository.UpdateAsync(coach);
        return Ok(coach);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var coach = await _coachRepository.GetByIdAsync(id);
        if (coach == null)
            return NotFound();

        await _coachRepository.RemoveAsync(coach);
        return NoContent();
    }
}