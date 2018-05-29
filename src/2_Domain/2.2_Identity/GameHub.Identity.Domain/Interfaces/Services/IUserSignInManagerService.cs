
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace GameHub.Identity.Domain.Interfaces.Services
{
    public interface IUserSignInManagerService
    {
        Task<SignInResult> SignInAsync(string userName, string password, bool rememberMe);
    }
}