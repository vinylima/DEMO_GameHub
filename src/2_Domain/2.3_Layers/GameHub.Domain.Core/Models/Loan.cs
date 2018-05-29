
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
        public DateTime? EfectiveDevolution { get; private set; }

        #endregion

        #region Constructors

        public Loan()
        {
            this.LoanId = Guid.NewGuid();
        }
        
        public Loan(Game game, Friend friend, DateTime loanDate) : base()
        {
            this.Game = game;
            this.Friend = friend;

            this.LoanDate = loanDate;
        }

        public Loan(Game game, Friend friend, DateTime loanDate, DateTime devolutionPrevision) : base()
        {
            this.Game = game;
            this.Friend = friend;

            this.LoanDate = loanDate;
            this.DevolutionPrevision = devolutionPrevision;
        }

        #endregion

        #region Factories

        public static Loan CreateNew(Guid loanId, Game game, Friend friend)
        {
            return new Loan
            {
                LoanId = loanId,
                Game = game,
                Friend = friend,
            };
        }

        public static Loan CreateNew(Game game, Friend friend)
        {
            return new Loan
            {
                LoanId = Guid.NewGuid(),
                Game = game,
                Friend = friend,
            };
        }

        #endregion
    }
}