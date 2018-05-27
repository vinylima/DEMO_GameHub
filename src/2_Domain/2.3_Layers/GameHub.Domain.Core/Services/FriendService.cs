
using GameHub.Domain.Core.Interfaces.Repositories;
using GameHub.Domain.Core.Interfaces.Services;
using GameHub.Domain.Core.Models;

namespace GameHub.Domain.Core.Services
{
    public class FriendService : BaseService<Friend>, IFriendService
    {
        public FriendService(IFriendRepository baseRepository) : base(baseRepository)
        {

        }
    }
}