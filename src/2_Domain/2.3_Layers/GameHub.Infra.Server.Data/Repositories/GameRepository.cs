
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using GameHub.Domain.Core.Interfaces.Repositories;
using GameHub.Domain.Core.Models;
using GameHub.Infra.Server.Data.Context;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Infra.Server.Data.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        GameHub_Context _context;
        public GameRepository(GameHub_Context context) : base(context)
        {

        }
        
        public async Task<IExecutionResult<IQueryable<Game>>> WhereAsync(Expression<Func<Game, bool>> predicate, bool getLoans)
        {
            IExecutionResult<IQueryable<Game>> execResult = new ExecutionResult<IQueryable<Game>>();

            try
            {
                if (getLoans)
                {
                    execResult.DefineResult(
                        this.RawDb.Set<Game>()
                            .AsNoTracking()
                            .Include(g => g.Loans)
                            .Where(predicate)
                    );

                    return execResult;
                }

                execResult.DefineResult(
                    this.RawDb.Set<Game>()
                        .AsNoTracking()
                        .Where(predicate)
                );
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(new Message("Erro ao realizar uma consulta especializada no banco de dados: " + e.Message.ToString()));
            }

            return execResult;
        }
    }
}