using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Controller;

[Route("api/workoutday")]
[ApiController]
[Authorize]
public class WorkoutDayController : ControllerBase
{
    private readonly WorkoutDayRepository _workoutDayRepository;

    public WorkoutDayController(WorkoutDayRepository workoutDayRepository)
    {
        _workoutDayRepository = workoutDayRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var workoutDays = await _workoutDayRepository.GetAllAsync();
        return Ok(workoutDays);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var workoutDay = await _workoutDayRepository.GetByIdAsync(id);
        if (workoutDay == null)
            return NotFound();
        
        return Ok(workoutDay);
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkoutDay workoutDay)
    {
        await _workoutDayRepository.AddAsync(workoutDay);
        return CreatedAtAction(nameof(GetById), new { id = workoutDay.Id }, workoutDay);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, WorkoutDay workoutDay)
    {
        if (id != workoutDay.Id)
            return BadRequest("ID mismatch");

        await _workoutDayRepository.UpdateAsync(workoutDay);
        return Ok(workoutDay);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var workoutDay = await _workoutDayRepository.GetByIdAsync(id);
        if (workoutDay == null)
            return NotFound();

        await _workoutDayRepository.RemoveAsync(workoutDay);
        return NoContent();
    }
}