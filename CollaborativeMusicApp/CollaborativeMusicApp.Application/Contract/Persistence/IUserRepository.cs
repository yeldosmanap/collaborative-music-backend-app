using CollaborativeMusicApp.Domain.Entities;

namespace CollaborativeMusicApp.Application.Contract.Persistence;

public interface IUserRepository : IAsyncRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}