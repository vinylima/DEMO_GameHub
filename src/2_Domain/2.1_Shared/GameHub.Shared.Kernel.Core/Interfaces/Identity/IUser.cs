
using System.Security.Claims;

using GameHub.Shared.Kernel.Core.Interfaces.Collections;

namespace GameHub.Shared.Kernel.Core.Interfaces.Identity
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
    }
}