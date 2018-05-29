
using System;
using System.Linq.Expressions;

using GameHub.Domain.Core.Models;

namespace GameHub.Domain.Core.Specifications.Games
{
    public static class SearchGameByIdSpec
    {
        public static Expression<Func<Game, bool>> SearchGameById(Guid gameId)
        {
            return g => g.GameId.Equals(gameId);
        }
    }
}