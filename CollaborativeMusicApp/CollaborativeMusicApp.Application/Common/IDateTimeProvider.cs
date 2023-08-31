namespace CollaborativeMusicApp.Application.Common;

public interface IDateTimeProvider
{
    DateTime UtcNow { get;  }
}