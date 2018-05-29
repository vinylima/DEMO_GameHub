
using System;

namespace GameHub.Application.ViewModels
{
    public class LoanViewModel : BaseViewModel<LoanViewModel>
    {
        private Guid loanId;
        private GameViewModel game;
        private FriendViewModel friend;
        private DateTime loanDate;
        private DateTime devolutionPrevision;
        private DateTime? efetiveDevolution;
        
        public LoanViewModel()
        {
            this.LoanId = Guid.NewGuid();
        }

        #region Gets and Sets

        public Guid LoanId
        {
            get { return this.loanId; }
            set { SetProperty(ref this.loanId, value); }
        }

        public GameViewModel Game
        {
            get
            {
                if (this.game != null)
                    this.game = new GameViewModel();

                return this.game;
            }
            set { SetProperty(ref this.game, value); }
        }

        public FriendViewModel Friend
        {
            get
            {
                if (this.friend == null)
                    this.friend = new FriendViewModel();

                return friend;
            }
            set { SetProperty(ref this.friend, value); }
        }

        public DateTime LoanDate
        {
            get { return loanDate; }
            set { SetProperty(ref this.loanDate, value); }
        }

        public DateTime DevolutionPrevision
        {
            get { return devolutionPrevision; }
            set { SetProperty(ref this.devolutionPrevision, value); }
        }

        public DateTime? EfetiveDevolution
        {
            get { return efetiveDevolution; }
            set { SetProperty(ref this.efetiveDevolution, value); }
        }

        #endregion
    }
}