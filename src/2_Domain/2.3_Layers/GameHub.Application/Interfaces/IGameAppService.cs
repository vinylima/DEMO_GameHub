
using System;
using System.Threading.Tasks;

using GameHub.Application.ViewModels;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.Interfaces.Application;

namespace GameHub.Application.Interfaces
{
    public interface IGameAppService : IBaseAppService<GameViewModel>
    {
        Task<IExecutionResult<GameViewModel>> SearchByIdAsync(Guid id, bool loadLoans);
    }
}
