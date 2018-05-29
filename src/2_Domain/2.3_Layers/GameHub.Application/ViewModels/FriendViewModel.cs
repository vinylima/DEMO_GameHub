
using System;
using System.ComponentModel.DataAnnotations;

using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Enums;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;

namespace GameHub.Application.ViewModels
{
    public class FriendViewModel : BaseViewModel<FriendViewModel>
    {
        private Guid friendId;
        private string name;
        private string imagePath;
        private string email;
        private ReputationLevel reputationLevel;

        private BaseCollection<GameViewModel> games;
        
        #region Gets and Sets

        [Key]
        public Guid FriendId
        {
            get { return friendId; }
            set { SetProperty(ref this.friendId, value); }
        }

        [Display(Name = "Nome")]
        [Required]
        [MinLength(10, ErrorMessage = "O Nome do seu amigo nao pode ser muito curto, ao menos 10 caracteres.")]
        [MaxLength(30, ErrorMessage = "O Nome do seu amigo é muito grande, tente abreviá-lo para conter no máximo 30 caracteres, ok?")]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref this.name, value); }
        }

        [Display(Name = "Foto")]
        public string ImagePath
        {
            get { return imagePath; }
            set { SetProperty(ref this.imagePath, value); }
        }

        [EmailAddress(ErrorMessage = "O Email é inválido, verifique se escreveu tudo corretamente.")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref this.email, value); }
        }

        [Display(Name = "Reputação")]
        public ReputationLevel ReputationLevel
        {
            get { return reputationLevel; }
            set { SetProperty(ref this.reputationLevel, value); }
        }

        public BaseCollection<GameViewModel> Games
        {
            get { return this.games; }
            set { SetProperty(ref this.games, value); }
        }

        #endregion
    }
}