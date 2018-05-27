
namespace GameHub.Shared.Kernel.Core.Interfaces.Identity
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
    }
}