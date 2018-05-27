
using System;
using System.Threading.Tasks;

using GameHub.Shared.Kernel.Core.Collections;

namespace GameHub.Shared.Kernel.Core.Interfaces.Application
{
    public interface IBaseAppService<TViewModel> where TViewModel : IViewModel
    {
        IExecutionResult<bool> Save(TViewModel obj);

        Task<IExecutionResult<bool>> SaveAsync(TViewModel obj);

        IExecutionResult SaveRange(TViewModel[] array);

        Task<IExecutionResult> SaveRangeAsync(TViewModel[] array);
        
        IExecutionResult<bool> Remove(Guid id);

        Task<IExecutionResult<bool>> RemoveAsync(Guid id);

        IExecutionResult<bool> Exists(Guid id);

        IExecutionResult<TViewModel> SearchById(Guid id);

        Task<IExecutionResult<TViewModel>> SearchByIdAsync(Guid id);

        IExecutionResult<BaseCollection<TViewModel>> LoadAll();

        Task<IExecutionResult<BaseCollection<TViewModel>>> LoadAllAsync();
    }
}