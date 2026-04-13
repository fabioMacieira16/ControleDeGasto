using FluentValidation;

namespace ApiDDD.Domain.Models.Validations
{
    /// <summary>
    /// Validador para a entidade Transacao.
    /// Verifica as regras básicas de estrutura da transação.
    /// As regras de negócio (menor de idade, compatibilidade de categoria) 
    /// são aplicadas na camada de serviço.
    /// </summary>
    public class TransacaoValidator : AbstractValidator<Transacao>
    {
        public TransacaoValidator()
        {
            // Descrição é obrigatória e não pode exceder 400 caracteres
            RuleFor(t => t.Descricao)
                .NotEmpty().WithMessage("A descrição da transação é obrigatória.")
                .MaximumLength(400).WithMessage("A descrição não pode ter mais de 400 caracteres.");

            // Valor deve ser positivo
            RuleFor(t => t.Valor)
                .GreaterThan(0).WithMessage("O valor da transação deve ser maior que zero.");

            // Pessoa deve estar informada
            RuleFor(t => t.PessoaId)
                .GreaterThan(0).WithMessage("A pessoa é obrigatória.");

            // Categoria deve estar informada
            RuleFor(t => t.CategoriaId)
                .GreaterThan(0).WithMessage("A categoria é obrigatória.");
        }
    }
}
