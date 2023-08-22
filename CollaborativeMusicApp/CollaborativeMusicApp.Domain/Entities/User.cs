using System.Text.Json.Serialization;
using CollaborativeMusicApp.Domain.Common;

namespace CollaborativeMusicApp.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string Username { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
}