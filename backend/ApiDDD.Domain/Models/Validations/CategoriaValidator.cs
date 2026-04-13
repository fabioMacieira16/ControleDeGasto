using FluentValidation;

namespace ApiDDD.Domain.Models.Validations
{
    /// <summary>
    /// Validador para a entidade Categoria.
    /// Garante que a descrição está dentro do tamanho permitido.
    /// </summary>
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            // Descrição é obrigatória e não pode exceder 400 caracteres
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("A descrição da categoria é obrigatória.")
                .MaximumLength(400).WithMessage("A descrição não pode ter mais de 400 caracteres.");
        }
    }
}
