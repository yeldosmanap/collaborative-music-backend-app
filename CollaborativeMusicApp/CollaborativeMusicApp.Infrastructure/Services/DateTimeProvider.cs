using CollaborativeMusicApp.Application.Common;

namespace CollaborativeMusicApp.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}