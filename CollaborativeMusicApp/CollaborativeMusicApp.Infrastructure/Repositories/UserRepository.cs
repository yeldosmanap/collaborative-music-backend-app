using CollaborativeMusicApp.Application.Contract.Persistence;
using CollaborativeMusicApp.Domain.Entities;
using CollaborativeMusicApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeMusicApp.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext dataContext) : base(dataContext)
    {
        
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dataContext.Users.FirstAsync(user => user.Email.Equals(email));
    }
}