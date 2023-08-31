using CollaborativeMusicApp.Application.Services;
using CollaborativeMusicApp.Domain.DTOs;
using CollaborativeMusicApp.Domain.DTOs.Login;
using CollaborativeMusicApp.Domain.DTOs.Register;
using Microsoft.AspNetCore.Mvc;

namespace CollaborativeMusicApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterUserResponseDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto registerUserRequestDto)
    {
        var result = await _authService.RegisterAsync(registerUserRequestDto);
        return Ok(result);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginUserResponseDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] LoginUserRequestDto loginUserRequestDto)
    {
        var result = await _authService.LoginAsync(loginUserRequestDto);
        return Ok(result);
    }
}