using ApiDDD.Domain.Models.Enums;
using System.Collections.Generic;

namespace ApiDDD.Domain.Models
{
    /// <summary>
    /// Representa uma categoria para classificar transações financeiras.
    /// A finalidade define quais tipos de transação podem usar esta categoria.
    /// </summary>
    public class Categoria : BaseEntity
    {
        /// <summary>Descrição da categoria. Máximo de 400 caracteres.</summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Define a finalidade da categoria:
        /// DESPESA - somente transações de despesa.
        /// RECEITA - somente transações de receita.
        /// AMBAS - qualquer tipo de transação.
        /// </summary>
        public FinalidadeCategoria Finalidade { get; set; }

        /// <summary>Transações classificadas nesta categoria.</summary>
        public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
