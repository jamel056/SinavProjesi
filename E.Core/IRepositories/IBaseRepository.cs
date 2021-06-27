using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E.Core.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
