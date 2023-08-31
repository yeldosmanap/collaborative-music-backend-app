using CollaborativeMusicApp.Domain.Common;

namespace CollaborativeMusicApp.Domain.DTOs.Register;

public record RegisterUserResponseDto(string Email, string Username, bool Success, string ErrorMessage) 
    : BaseResponseDto(Success, ErrorMessage)
{
    public string Email { get; } = Email;
    public string Username { get; } = Username;
}