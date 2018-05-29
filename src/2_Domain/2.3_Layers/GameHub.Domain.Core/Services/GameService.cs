
using System;
using System.Linq;
using System.Threading.Tasks;

using GameHub.Domain.Core.Interfaces.Repositories;
using GameHub.Domain.Core.Interfaces.Services;
using GameHub.Domain.Core.Models;
using GameHub.Domain.Core.Specifications.Games;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Domain.Core.Services
{
    public class GameService : BaseService<Game>, IGameService
    {
        private IGameRepository _gameRepository { get; set; }

        public GameService(IGameRepository gameRepository) : base(gameRepository)
        {
            this._gameRepository = gameRepository;
        }

        public IExecutionResult GiveBack(Game game)
        {
            var result = new ExecutionResult();

            return result;
        }

        public IExecutionResult<bool> IsBorrowed(Guid gameId)
        {
            var result = new ExecutionResult<bool>();

            

            return result;
        }

        public IExecutionResult LendGame(Loan loan)
        {
            var result = new ExecutionResult();



            return result;
        }

        public async Task<IExecutionResult<Game>> SearchByIdAsync(Guid id, bool loadLoans)
        {
            IExecutionResult<Game> result = new ExecutionResult<Game>();
            
            try
            {
                var results = await this._gameRepository.WhereAsync(SearchGameByIdSpec.SearchGameById(id), true);

                result.Merge(results);

                result.DefineResult(results.ReturnResult.FirstOrDefault());

                results.Dispose();
                results = null;
            }
            catch(Exception e)
            {
                result.SystemErrors.Add(new Message("Erro ao Recuperar as Informações do Jogo."));
            }
            
            return result;
        }
    }
}