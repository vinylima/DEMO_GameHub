
using System;

using GameHub.Domain.Core.Validations;
using GameHub.Domain.Core.Scopes.ExecutionResultScopes;
using GameHub.Shared.Kernel.Core.Interfaces.Domain;
using GameHub.Shared.Kernel.Core.ValueObjects;
using GameHub.Domain.Core.Collections;

namespace GameHub.Domain.Core.Models
{
    public class Game : IModel
    {
        public Guid GameId { get; private set; }
        public string Title { get; private set; }
        public string ImagePath { get; private set; }
        public bool IsFavorite { get; private set; }
        public bool IsBorrowed { get; private set; }
        
        public DateTime? LastLoan { get; private set; }
        
        public Loan CurrentLoan { get; private set; }
        public LoanCollection Loans { get; private set; }

        #region Constructors

        public Game()
        {
            this.GameId = Guid.NewGuid();
        }

        public Game(Guid gameId, string title, Uri imagePath)
        {
            this.GameId = gameId;
            this.Title = title;
            this.ImagePath = imagePath.ToString();
        }

        public Game(Guid gameId, string title, Uri imagePath, bool isFavorite, bool isBorrowed,
            DateTime lastLoan, Loan currentLoan)
        {
            this.GameId = gameId;
            this.Title = title;
            this.ImagePath = imagePath.ToString();
            this.IsFavorite = isFavorite;
            this.IsBorrowed = isBorrowed;
            this.LastLoan = lastLoan;
            this.CurrentLoan = currentLoan;
        }

        #endregion

        #region Factories

        public static Game CreateNew(Guid gameId, string title, Uri imagePath, bool isFavorite, bool isBorrowed,
            DateTime? lastLoan)
        {
            return new Game
            {
                GameId = gameId,
                Title = title,
                ImagePath = imagePath.ToString(),
                IsFavorite = isFavorite,
                IsBorrowed = isBorrowed,
                LastLoan = lastLoan,
            };
        }

        public static Game CreateNew(string title, Uri imagePath, bool isFavorite, bool isBorrowed,
            DateTime? lastLoan)
        {
            return new Game
            {
                GameId = Guid.NewGuid(),
                Title = title,
                ImagePath = imagePath.ToString(),
                IsFavorite = isFavorite,
                IsBorrowed = isBorrowed,
                LastLoan = lastLoan,
            };
        }

        public static Game CreateNew(Guid gameId, string title, Uri imagePath, bool isFavorite)
        {
            return new Game
            {
                GameId = gameId,
                Title = title,
                ImagePath = imagePath.ToString(),
                IsFavorite = isFavorite,
            };
        }

        public static Game CreateNew(string title, Uri imagePath, bool isFavorite)
        {
            return new Game
            {
                GameId = Guid.NewGuid(),
                Title = title,
                ImagePath = imagePath.ToString(),
                IsFavorite = isFavorite,
            };
        }

        #endregion

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }

        public ExecutionResult<bool> IsValid()
        {
            var result = new ExecutionResult<bool>();

            result.Merge(
                new GameValidation().Validate(this)
            );

            return result;
        }

        public Guid GetId()
        {
            return this.GameId;
        }
        
        public void LendTo(Friend friend)
        {
            if (friend != null)
                this.CurrentLoan = Loan.CreateNew(this, friend);
        }

        public void AssignLoan(Loan loan)
        { this.CurrentLoan = loan; }

        public void DefineLastLoanDate(DateTime loanDate)
        { this.LastLoan = loanDate; }

        public void DefineBorrowedStatus(bool isBorrowed)
        { this.IsBorrowed = isBorrowed; }
    }
}