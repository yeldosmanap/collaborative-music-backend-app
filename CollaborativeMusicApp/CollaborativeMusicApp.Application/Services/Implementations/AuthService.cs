using CollaborativeMusicApp.Application.Contract.Persistence;
using CollaborativeMusicApp.Application.Exceptions;
using CollaborativeMusicApp.Domain.DTOs;
using CollaborativeMusicApp.Domain.DTOs.Login;
using CollaborativeMusicApp.Domain.DTOs.Register;
using CollaborativeMusicApp.Domain.Entities;

namespace CollaborativeMusicApp.Application.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<RegisterUserResponseDto> RegisterAsync(RegisterUserRequestDto registerUserRequestDto)
    {
        var userByEmailAsync = await _userRepository.GetUserByEmailAsync(registerUserRequestDto.Email);
        if (userByEmailAsync != null)
        {
            throw new UserAlreadyExistsByEmailException("User already exists with this email");
        }
        
        User user = new()
        {
            Email = registerUserRequestDto.Username,
            Password = registerUserRequestDto.Password,
            Username = registerUserRequestDto.Username
        };
        
        await _userRepository.AddAsync(user);
        
        return new RegisterUserResponseDto(user.Email, user.Username, true, "");
    }

    public Task<LoginUserResponseDto> LoginAsync(LoginUserRequestDto loginUserRequestDto)
    {
        throw new NotImplementedException();
    }
}