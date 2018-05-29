
using System;
using System.Linq;
using System.Linq.Expressions;

using System.Threading.Tasks;
using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces.Domain;

namespace GameHub.Shared.Kernel.Core.Interfaces.Repositories
{
    public interface IBaseReadOnlyRepository<TEntity> : IDisposable where TEntity : IModel
    {
        IExecutionResult<bool> Exists(Guid id);
        
        IExecutionResult<TEntity> SearchById(Guid id);

        Task<IExecutionResult<TEntity>> SearchByIdAsync(Guid id);

        IExecutionResult<BaseCollection<TEntity>> GetAll();

        Task<IExecutionResult<BaseCollection<TEntity>>> GetAllAsync();

        IExecutionResult<BaseCollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task<IExecutionResult<BaseCollection<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        IExecutionResult<IQueryable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        Task<IExecutionResult<IQueryable<TEntity>>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
    }
}