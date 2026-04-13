using ApiDDD.Domain.Models;
using FluentValidation;

namespace ApiDDD.Domain.Models.Validations
{
    /// <summary>
    /// Validador para a entidade Pessoa.
    /// Garante que os dados obrigatórios estão corretos antes de persistir.
    /// </summary>
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            // Nome é obrigatório e não pode exceder 200 caracteres
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(200).WithMessage("O nome não pode ter mais de 200 caracteres.");

            // Idade deve ser um valor não negativo
            RuleFor(p => p.Idade)
                .GreaterThanOrEqualTo(0).WithMessage("A idade não pode ser negativa.");
        }
    }
}
