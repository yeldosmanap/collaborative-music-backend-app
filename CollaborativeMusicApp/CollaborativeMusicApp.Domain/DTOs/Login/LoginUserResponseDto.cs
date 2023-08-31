using CollaborativeMusicApp.Domain.Common;

namespace CollaborativeMusicApp.Domain.DTOs.Login;

public record LoginUserResponseDto(string Email, string Username, string AccessToken, bool Success, string ErrorMessage) 
    : BaseResponseDto(Success, ErrorMessage)
{
    public string Email { get; } = Email;
    public string Username { get; } = Username;
    public string AccessToken { get; } = AccessToken; 
}