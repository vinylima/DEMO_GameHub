
using System;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using GameHub.Identity.Domain.Interfaces.Repositories;
using GameHub.Identity.Domain.Interfaces.Services;
using GameHub.Identity.Domain.Models;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;

namespace GameHub.Identity.Domain.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IUserManagerRepository _db;

        public UserManagerService(IUserManagerRepository userManagerRepository)
        {
            this._db = userManagerRepository;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            return await this._db.CreateAsync(user);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return await this._db.CreateAsync(user, password);
        }

        public IBaseCollection<ApplicationUser> Find(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return this._db.Find(predicate);
        }

        public IBaseCollection<ApplicationUser> GetAll()
        {
            return this._db.GetAll();
        }

        public ApplicationUser SearchById(IIdentity id)
        {
            return this._db.SearchById(id);
        }
    }
}