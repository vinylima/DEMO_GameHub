
using System;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Application.ViewModels
{
    public class CategoryViewModel : BaseViewModel<CategoryViewModel>
    {
        private Guid categoryId;
        private string name;

        #region Gets and Sets

        public Guid CategoryId
        {
            get { return categoryId; }
            set { SetProperty(ref this.categoryId, value); }
        }

        [Required]
        [MinLength(5, ErrorMessage = "O nome da Categoria precisa ter ao menos 5 caracteres")]
        [MaxLength(20, ErrorMessage = "O nome da Categoria deve ter, ao máximo, 20 caracteres")]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref this.name, value); }
        }

        #endregion
    }
}