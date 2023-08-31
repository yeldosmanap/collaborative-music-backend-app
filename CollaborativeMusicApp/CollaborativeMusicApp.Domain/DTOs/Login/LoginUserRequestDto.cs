namespace CollaborativeMusicApp.Domain.DTOs.Login;

public record LoginUserRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}