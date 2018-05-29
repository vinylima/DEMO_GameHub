
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using GameHub.Identity.Domain.Models;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;
using System.Security.Principal;

namespace GameHub.Identity.Domain.Interfaces.Repositories
{
    public interface IUserManagerRepository
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);

        ApplicationUser SearchById(IIdentity id);
        ApplicationUser SearchByUserName(string userName);
        bool UserExists(string userName);
        IBaseCollection<ApplicationUser> GetAll();
        IBaseCollection<ApplicationUser> Find(Expression<Func<ApplicationUser, bool>> predicate);
    }
}