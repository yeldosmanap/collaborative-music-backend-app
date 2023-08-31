using CollaborativeMusicApp.Application.Contract.Persistence;
using CollaborativeMusicApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeMusicApp.Infrastructure.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly AppDbContext _dataContext;

    public BaseRepository(AppDbContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dataContext.Set<T>().FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dataContext.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dataContext.Set<T>().AddAsync(entity);
        await _dataContext.SaveChangesAsync();
        
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dataContext.Set<T>().Update(entity);
        await _dataContext.SaveChangesAsync();
        
        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _dataContext.Set<T>().Remove(entity);
        _dataContext.Entry(entity).State = EntityState.Deleted;
        
        await _dataContext.SaveChangesAsync();

        return entity;
    }
}