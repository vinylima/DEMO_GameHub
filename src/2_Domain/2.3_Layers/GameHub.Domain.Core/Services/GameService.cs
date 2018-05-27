
using GameHub.Domain.Core.Interfaces.Repositories;
using GameHub.Domain.Core.Interfaces.Services;
using GameHub.Domain.Core.Models;

namespace GameHub.Domain.Core.Services
{
    public class GameService : BaseService<Game>, IGameService
    {
        public GameService(IGameRepository baseRepository) : base(baseRepository)
        {
        }
    }
}