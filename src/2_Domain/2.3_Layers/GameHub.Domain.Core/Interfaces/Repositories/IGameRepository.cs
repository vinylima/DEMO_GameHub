
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using GameHub.Domain.Core.Models;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.Interfaces.Repositories;

namespace GameHub.Domain.Core.Interfaces.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<IExecutionResult<IQueryable<Game>>> WhereAsync(Expression<Func<Game, bool>> predicate, bool getLoans);
    }
}