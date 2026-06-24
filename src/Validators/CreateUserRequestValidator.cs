namespace LicitaRadarApi.Validators;

using FluentValidation;
using LicitaRadarApi.DTO;

public class CreateUserRequestValidator : AbstractValidator<DtoUserCreate>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Sobrenome é obrigatório")
            .MaximumLength(100).WithMessage("Sobrenome deve ter no máximo 100 caracteres");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório")
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(x => x.NumberPhone)
            .NotEmpty().WithMessage("Telefone é obrigatório")
            .Matches(@"^\+?[1-9]\d{7,14}$").WithMessage("Telefone inválido");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é obrigatória")
            .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres");
    }
}