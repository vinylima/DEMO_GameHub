
using System;
using System.Threading.Tasks;

using GameHub.Domain.Core.Models;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.Interfaces.Services;

namespace GameHub.Domain.Core.Interfaces.Services
{
    public interface IGameService : IBaseService<Game>
    {
        Task<IExecutionResult<Game>> SearchByIdAsync(Guid id, bool loadLoans);

        IExecutionResult<bool> IsBorrowed(Guid gameId);

        IExecutionResult LendGame(Loan loan);

        IExecutionResult GiveBack(Game game);
    }
}