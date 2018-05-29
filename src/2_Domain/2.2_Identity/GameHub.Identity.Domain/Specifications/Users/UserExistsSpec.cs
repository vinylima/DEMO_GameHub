
using System;
using System.Linq.Expressions;

using GameHub.Identity.Domain.Models;

namespace GameHub.Identity.Domain.Specifications.Users
{
    public static class UserExistsSpec
    {
        public static Expression<Func<ApplicationUser, bool>> UserExists(string userName)
        {
            return u => u.UserName.ToLower().Equals(userName.ToLower());
        }
    }
}