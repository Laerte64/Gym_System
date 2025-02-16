using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Controller;

[Route("api/split")]
[ApiController]
[Authorize]
public class SplitController : ControllerBase
{
    private readonly SplitRepository _splitRepository;

    public SplitController(SplitRepository splitRepository)
    {
        _splitRepository = splitRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var splits = await _splitRepository.GetAllAsync();
        return Ok(splits);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var split = await _splitRepository.GetByIdAsync(id);
        if (split == null)
            return NotFound();
        
        return Ok(split);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Split split)
    {
        await _splitRepository.AddAsync(split);
        return CreatedAtAction(nameof(GetById), new { id = split.Id }, split);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Split split)
    {
        if (id != split.Id)
            return BadRequest("ID mismatch");

        await _splitRepository.UpdateAsync(split);
        return Ok(split);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var split = await _splitRepository.GetByIdAsync(id);
        if (split == null)
            return NotFound();

        await _splitRepository.RemoveAsync(split);
        return NoContent();
    }
}