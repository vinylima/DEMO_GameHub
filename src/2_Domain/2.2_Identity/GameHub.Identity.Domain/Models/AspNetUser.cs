
using System.Security.Claims;

using Microsoft.AspNetCore.Http;

using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;
using GameHub.Shared.Kernel.Core.Interfaces.Identity;

namespace GameHub.Identity.Domain.Models
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _acessor;

        public AspNetUser(IHttpContextAccessor acessor)
        {
            this._acessor = acessor;
        }

        public string Name
        {
            get { return this._acessor.HttpContext.User.Identity.Name; }
        }
        
        public bool IsAuthenticated()
        {
            return this._acessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}