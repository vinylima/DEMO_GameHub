
using GameHub.Domain.Core.Interfaces.Repositories;
using GameHub.Domain.Core.Models;
using GameHub.Infra.Server.Data.Context;

namespace GameHub.Infra.Server.Data.Repositories
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        public FriendRepository(GameHub_Context context) : base(context)
        {
        }
    }
}