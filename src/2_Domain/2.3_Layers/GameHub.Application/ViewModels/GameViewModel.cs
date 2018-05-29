
using System;
using System.ComponentModel.DataAnnotations;
using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;

namespace GameHub.Application.ViewModels
{
    public class GameViewModel : BaseViewModel<GameViewModel>
    {
        private Guid gameId;
        private string title;
        private string imagePath;
        private bool isFavorite;
        private bool isBorrowed;
        private DateTime? lastLoan;
        private string status;

        private LoanViewModel currentLoan;

        private BaseCollection<LoanViewModel> loans;

        public GameViewModel()
        {
            this.GameId = Guid.NewGuid();
        }

        #region Gets and Sets

        [Key]
        public Guid GameId
        {
            get { return gameId; }
            set { SetProperty(ref this.gameId, value); }
        }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Por favor, insira o Nome do Jogo, informação necessária.")]
        [MinLength(5, ErrorMessage = "O Nome do Jogo precisa ter ao menos 5 Caracteres.")]
        [MaxLength(30, ErrorMessage = "O Nome desse Jogo está muito grande pra lembrar depois... Por favor, reduza para 30 caracteres no máximo.")]
        public string Title
        {
            get { return title; }
            set { SetProperty(ref this.title, value); }
        }

        [Display(Name = "Banner")]
        [Required(ErrorMessage = "Para facilitar a visualizacao do Jogo, por favor, coloque uma imagem.")]
        public string ImagePath
        {
            get { return imagePath; }
            set { SetProperty(ref this.imagePath, value); }
        }

        [Display(Name = "Jogo Favorito?")]
        public bool IsFavorite
        {
            get { return isFavorite; }
            set { SetProperty(ref this.isFavorite, value); }
        }

        [Display(Name = "Está Emprestado?")]
        public bool IsBorrowed
        {
            get { return isBorrowed; }
            set { SetProperty(ref this.isBorrowed, value); }
        }

        [Display(Name = "Último Empréstimo:")]
        public DateTime? LastLoan
        {
            get { return this.lastLoan; }
            set { SetProperty(ref this.lastLoan, value); }
        }

        [Display(Name = "Status:")]
        public string Status
        {
            get { return status; }
            set { SetProperty(ref this.status, value); }
        }

        public LoanViewModel CurrentLoan
        {
            get
            {
                if (this.currentLoan == null)
                    this.currentLoan = new LoanViewModel();

                return this.currentLoan;
            }
            set { SetProperty(ref this.currentLoan, value); }
        }

        public BaseCollection<LoanViewModel> Loans
        {
            get
            {
                if (this.loans == null)
                    this.loans = new BaseCollection<LoanViewModel>();

                return this.loans;
            }
            set
            {
                this.loans = value;
            }
        }

        #endregion
    }
}