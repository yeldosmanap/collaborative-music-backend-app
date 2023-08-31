using System.Security.Authentication;
using CollaborativeMusicApp.Application.Common;
using CollaborativeMusicApp.Application.Contract.Persistence;
using CollaborativeMusicApp.Application.Exceptions;
using CollaborativeMusicApp.Domain.DTOs;
using CollaborativeMusicApp.Domain.DTOs.Login;
using CollaborativeMusicApp.Domain.DTOs.Register;
using CollaborativeMusicApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CollaborativeMusicApp.Application.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
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
            Email = registerUserRequestDto.Email,
            Password = registerUserRequestDto.Password,
            Username = registerUserRequestDto.Username
        };
        
        user.Password = _passwordHasher.HashPassword(user, user.Password);
        
        await _userRepository.AddAsync(user);
        
        return new RegisterUserResponseDto(user.Email, user.Username, true, "");
    }

    public async Task<LoginUserResponseDto> LoginAsync(LoginUserRequestDto loginUserRequestDto)
    {
        if (string.IsNullOrEmpty(loginUserRequestDto.Email) || string.IsNullOrEmpty(loginUserRequestDto.Password))
        {
            throw new Exception("Email and password are required");
        }

        // 1. Get a user by email
        var user = await _userRepository.GetUserByEmailAsync(loginUserRequestDto.Email);
        if (user == null)
        {
            throw new Exception("User does not exist");
        }

        // 2. Validate the password
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password,
            loginUserRequestDto.Password);
        if (passwordVerificationResult != PasswordVerificationResult.Success)
        {
            throw new InvalidCredentialException("Invalid password");
        }

        // 3. Generate the token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Username, user.Email);

        return new LoginUserResponseDto(
            user.Email,
            user.Username,
            token,
            true,
            ""
        );
    }
}