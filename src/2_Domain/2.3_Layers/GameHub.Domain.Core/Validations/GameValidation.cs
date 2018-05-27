
using FluentValidation;
using GameHub.Domain.Core.Models;

namespace GameHub.Domain.Core.Validations
{
    public class GameValidation : AbstractValidator<Game>
    {
        public GameValidation()
        {
            
        }
    }
}