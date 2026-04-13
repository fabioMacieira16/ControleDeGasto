using System.Collections.Generic;

namespace ApiDDD.Domain.Models
{
    /// <summary>
    /// Representa uma pessoa cadastrada no sistema.
    /// Uma pessoa pode ter várias transações vinculadas.
    /// Ao deletar uma pessoa, todas as suas transações são removidas em cascata.
    /// </summary>
    public class Pessoa : BaseEntity
    {
        /// <summary>Nome da pessoa. Máximo de 200 caracteres.</summary>
        public string Nome { get; set; }

        /// <summary>Idade da pessoa. Menores de 18 anos só podem registrar DESPESAS.</summary>
        public int Idade { get; set; }

        /// <summary>Transações financeiras vinculadas a esta pessoa.</summary>
        public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
