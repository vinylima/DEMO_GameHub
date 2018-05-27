
using System;
using System.Threading.Tasks;

using GameHub.Shared.Kernel.Core.Interfaces.Domain;

namespace GameHub.Shared.Kernel.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseReadOnlyRepository<TEntity>, IDisposable where TEntity : IModel
    {
        IExecutionResult<bool> Save(TEntity obj);

        Task<IExecutionResult<bool>> SaveAsync(TEntity obj);

        IExecutionResult SaveRange(TEntity[] array);

        Task<IExecutionResult> SaveRangeAsync(TEntity[] array);

        IExecutionResult<bool> Update(TEntity obj);

        Task<IExecutionResult<bool>> UpdateAsync(TEntity obj);

        IExecutionResult<bool> Remove(Guid id);

        Task<IExecutionResult<bool>> RemoveAsync(Guid id);

        IExecutionResult<bool> SaveChanges();
    }
}