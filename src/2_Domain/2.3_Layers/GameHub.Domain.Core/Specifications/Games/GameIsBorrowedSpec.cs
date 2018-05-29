
using System;
using System.Linq.Expressions;

using GameHub.Domain.Core.Models;

namespace GameHub.Domain.Core.Specifications.Games
{
    public static class GameIsBorrowedSpec
    {
        public static Expression<Func<Game, bool>> GameIsBorrowed(Guid gameId)
        {
            return g => g.GameId.Equals(gameId) && g.IsBorrowed;
        }
    }
}