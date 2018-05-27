
using GameHub.Domain.Core.Interfaces.Repositories;
using GameHub.Domain.Core.Models;
using GameHub.Infra.Server.Data.Context;

namespace GameHub.Infra.Server.Data.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GameHub_Context context) : base(context)
        {
        }
    }
}