
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace GameHub.Identity.Domain.Interfaces.Repositories
{
    public interface IUserSignInManagerRepository
    {
        Task<SignInResult> SignInAsync(string userName, string password, bool rememberMe);
    }
}