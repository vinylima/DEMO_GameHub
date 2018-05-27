
using System;

using GameHub.Shared.Kernel.Core.Interfaces.Identity;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Shared.Kernel.Core.Interfaces.Domain
{
    public interface IModel : IIdentity, IDisposable
    {
        ExecutionResult<bool> IsValid();
    }
}