
using FluentValidation;

using GameHub.Domain.Core.Models;

namespace GameHub.Domain.Core.Validations
{
    public class FriendValidation : AbstractValidator<Friend>
    {
        public FriendValidation()
        {
            RuleFor(f => f.Name)
                .MinimumLength(10)
                    .WithMessage("Para nao confundir, o nome do seu amigo precisa ter ao menos 10 caracteres ;p.")
                .MaximumLength(30)
                    .WithMessage("O Nome do seu amigo ultrapassou o limite de caracteres, tente abreviá-lo, ok?");

            RuleFor(f => f.Email)
                .EmailAddress()
                    .WithMessage("A informacao inserida no campo Email é inválida, digite um email ou entao, retire a informacao.")
                .When(f => !string.IsNullOrWhiteSpace(f.Email));
        }
    }
}