
using System;

namespace GameHub.Domain.Core.Models
{
    public class Loan
    {
        #region Gets and Sets

        public Guid LoanId { get; private set; }

        public Guid GameId { get; private set; }

        private Game game;
        public Game Game
        {
            get
            {
                if (this.game == null)
                    this.game = new Game();

                return this.game;
            }
            private set
            {
                this.game = value;
                this.GameId = value.GameId;
            }
        }
        
        public Guid FriendId { get; private set; }
        private Friend friend;
        public Friend Friend
        {
            get
            {
                if (this.friend == null)
                    this.friend = new Friend();

                return this.friend;
            }
            private set
            {
                this.friend = value;
                this.FriendId = value.FriendId;
            }
        }

        public DateTime LoanDate { get; private set; }
        public DateTime DevolutionPrevision { get; private set; }
        public DateTime EfectiveDevolution { get; private set; }

        #endregion

        #region Constructors

        public Loan()
        {
            this.LoanId = Guid.NewGuid();

            this.Friend = new Friend();
            this.Game = new Game();
        }

        public Loan(Guid loanId, Guid gameId, Game game, Guid friendId, Friend friend)
        {
            this.LoanId = loanId;

            this.GameId = gameId;
            this.Game = game;

            this.FriendId = friendId;
            this.Friend = friend;
        }

        public Loan(Guid gameId, Game game, Guid friendId, Friend friend)
        {
            this.LoanId = Guid.NewGuid();

            this.GameId = gameId;
            this.Game = game;

            this.FriendId = friendId;
            this.Friend = friend;
        }

        #endregion

        #region Factories

        public static Loan CreateNew(Guid loanId, Guid gameId, Game game, Guid friendId, Friend friend)
        {
            return new Loan
            {
                LoanId = loanId,
                GameId = gameId,
                Game = game,
                FriendId = friendId,
                Friend = friend,
            };
        }

        public Loan CreateNew(Guid gameId, Game game, Guid friendId, Friend friend)
        {
            return new Loan
            {
                LoanId = Guid.NewGuid(),
                GameId = gameId,
                Game = game,
                FriendId = friendId,
                Friend = friend,
            };
        }

        #endregion
    }
}