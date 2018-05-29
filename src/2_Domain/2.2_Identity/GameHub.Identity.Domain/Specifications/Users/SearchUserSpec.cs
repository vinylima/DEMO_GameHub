
using System;
using System.Linq.Expressions;

using GameHub.Identity.Domain.Models;

namespace GameHub.Identity.Domain.Specifications.Users
{
    public static class SearchUserSpec
    {
        public static Expression<Func<ApplicationUser, bool>> SearchUser(string userName)
        {
            return u => u.UserName.ToLower().Equals(userName.ToLower());
        }
    }
}