using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestClean.Domain.Entities;

namespace TestClean.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{

    Task<MeetingEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
    // Add other methods as needed
}
