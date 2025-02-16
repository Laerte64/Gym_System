using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Model.DTO;
using Interface;
using Services;

namespace Controller;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public UserController(UserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userRepository.AuthenticateAsync(request.Login, request.Password);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _jwtService.GenerateToken(user);
        return Ok(new { Token = token });
    }
}