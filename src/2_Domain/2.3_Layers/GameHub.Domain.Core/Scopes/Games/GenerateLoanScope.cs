
using System;

using GameHub.Domain.Core.Models;

namespace GameHub.Domain.Core.Scopes.Games
{
    public static class GenerateLoanScope
    {
        public static Loan GenerateLoan(this Game game, Friend friend, DateTime loanDate)
        {
            return new Loan(game, friend, loanDate);
        }

        public static Loan GenerateLoan(this Game game, Friend friend, DateTime loanDate, DateTime devolutionPrevision)
        {
            return new Loan(game, friend, loanDate, devolutionPrevision);
        }
    }
}