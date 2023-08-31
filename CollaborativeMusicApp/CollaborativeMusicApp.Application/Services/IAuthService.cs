using CollaborativeMusicApp.Domain.DTOs;
using CollaborativeMusicApp.Domain.DTOs.Login;
using CollaborativeMusicApp.Domain.DTOs.Register;
using CollaborativeMusicApp.Domain.Entities;

namespace CollaborativeMusicApp.Application.Services;

public interface IAuthService
{
    Task<LoginUserResponseDto> LoginAsync(LoginUserRequestDto loginUserRequestDto);
    Task<RegisterUserResponseDto> RegisterAsync(RegisterUserRequestDto registerUserRequestDto);
}