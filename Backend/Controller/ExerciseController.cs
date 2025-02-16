namespace Controller;

using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

[Route("api/exercise")]
[ApiController]
[Authorize]
public class ExerciseController : ControllerBase
{
    private readonly ExerciseRepository _exerciseRepository;

    public ExerciseController(ExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var exercises = await _exerciseRepository.GetAllAsync();
        return Ok(exercises);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(id);
        if (exercise == null)
            return NotFound();
        
        return Ok(exercise);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Exercise exercise)
    {
        await _exerciseRepository.AddAsync(exercise);
        return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Exercise exercise)
    {
        if (id != exercise.Id)
            return BadRequest("ID mismatch");

        await _exerciseRepository.UpdateAsync(exercise);
        return Ok(exercise);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(id);
        if (exercise == null)
            return NotFound();

        await _exerciseRepository.RemoveAsync(exercise);
        return NoContent();
    }
}