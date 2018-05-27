
using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;
using GameHub.Shared.Kernel.Core.Interfaces.Domain;
using GameHub.Shared.Kernel.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Shared.Kernel.Core.Interfaces.Services
{
    public interface IBaseService<TModel> : IDisposable where TModel : IModel
    {
        IExecutionResult<bool> Save(TModel obj);

        Task<IExecutionResult<bool>> SaveAsync(TModel obj);

        IExecutionResult SaveRange(TModel[] array);

        Task<IExecutionResult> SaveRangeAsync(TModel[] array);

        IExecutionResult<bool> Remove(Guid id);

        Task<IExecutionResult<bool>> RemoveAsync(Guid id);

        IExecutionResult<bool> Exists(Guid id);

        IExecutionResult<TModel> SearchById(Guid id);

        Task<IExecutionResult<TModel>> SearchByIdAsync(Guid id);

        IExecutionResult<BaseCollection<TModel>> LoadAll();

        Task<IExecutionResult<BaseCollection<TModel>>> LoadAllAsync();

        IExecutionResult<BaseCollection<TModel>> Find(Expression<Func<TModel, bool>> predicate, bool tracking);

        Task<IExecutionResult<BaseCollection<TModel>>> FindAsync(Expression<Func<TModel, bool>> predicate, bool tracking);
    }
}