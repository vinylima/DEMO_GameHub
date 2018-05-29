
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using GameHub.Identity.Domain.Interfaces.Repositories;
using GameHub.Identity.Domain.Interfaces.Services;

namespace GameHub.Identity.Domain.Services
{
    public class UserSigInManagerService : IUserSignInManagerService
    {
        private readonly IUserSignInManagerRepository _signInManager;


        public UserSigInManagerService(IUserSignInManagerRepository userSignInManagerRepository)
        {
            this._signInManager = userSignInManagerRepository;
        }

        public async Task<SignInResult> SignInAsync(string userName, string password, bool rememberMe)
        {
            return await this._signInManager.SignInAsync(userName, password, rememberMe);
        }
    }
}