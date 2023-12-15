
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestClean.Domain.Entities;
using TestClean.Domain.Interfaces;
using TestClean.Infrastructure.Data;

namespace TestClean.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var meeting = await GetByIdAsync(id);
        if (meeting != null)
        {
            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
        }

    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return entity!;
        }
        catch
        {
            return null!;
        }
    }

    public async Task<MeetingEntity> GetByIdAsync(int id)
    {
        var meetingExists = await _context.Meetings.FindAsync(id);
        if (meetingExists == null) { return null!; }
        return meetingExists;

    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
