
using System;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using GameHub.Identity.Domain.Models;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;

namespace GameHub.Identity.Domain.Interfaces.Services
{
    public interface IUserManagerService
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);

        ApplicationUser SearchById(IIdentity id);
        IBaseCollection<ApplicationUser> GetAll();
        IBaseCollection<ApplicationUser> Find(Expression<Func<ApplicationUser, bool>> predicate);
    }
}