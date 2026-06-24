using FluentValidation;
using LicitaRadarApi.DTO;

namespace LicitaRadarApi.Validators;

public class UpdateUserRequestValidator : AbstractValidator<DtoUser>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome não pode ser vazio")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres")
            .When(x => x.Name is not null);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Sobrenome não pode ser vazio")
            .MaximumLength(100).WithMessage("Sobrenome deve ter no máximo 100 caracteres")
            .When(x => x.LastName is not null);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email não pode ser vazio")
            .EmailAddress().WithMessage("Email inválido")
            .When(x => x.Email is not null);

        RuleFor(x => x.NumberPhone)
            .NotEmpty().WithMessage("Telefone não pode ser vazio")
            .Matches(@"^\+?[1-9]\d{7,14}$").WithMessage("Telefone inválido")
            .When(x => x.NumberPhone is not null);
    }
}