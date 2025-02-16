using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Controller;

[Route("api/member")][Route("api/member")]
[ApiController]
[Authorize]
public class MemberController : ControllerBase
{
    private readonly MemberRepository _memberRepository;

    public MemberController(MemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var members = await _memberRepository.GetAllAsync();
        return Ok(members);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var member = await _memberRepository.GetByIdAsync(id);
        if (member == null)
            return NotFound();
        
        return Ok(member);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Member member)
    {
        await _memberRepository.AddAsync(member);
        return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Member member)
    {
        if (id != member.Id)
            return BadRequest("ID mismatch");

        await _memberRepository.UpdateAsync(member);
        return Ok(member);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var member = await _memberRepository.GetByIdAsync(id);
        if (member == null)
            return NotFound();

        await _memberRepository.RemoveAsync(member);
        return NoContent();
    }
}
