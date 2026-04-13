using ApiDDD.Domain.Models.Enums;

namespace ApiDDD.Domain.Models
{
    /// <summary>
    /// Representa uma transação financeira (despesa ou receita) vinculada a uma pessoa e uma categoria.
    /// Regras de negócio:
    /// - O valor deve ser positivo.
    /// - Pessoas menores de 18 anos só podem registrar DESPESAS.
    /// - A categoria deve ser compatível com o tipo da transação.
    /// </summary>
    public class Transacao : BaseEntity
    {
        /// <summary>Descrição da transação. Máximo de 400 caracteres.</summary>
        public string Descricao { get; set; }

        /// <summary>Valor da transação. Deve ser sempre positivo.</summary>
        public decimal Valor { get; set; }

        /// <summary>Tipo da transação: DESPESA ou RECEITA.</summary>
        public TipoTransacao Tipo { get; set; }

        /// <summary>Identificador da categoria associada.</summary>
        public long CategoriaId { get; set; }

        /// <summary>Categoria associada a esta transação.</summary>
        public virtual Categoria Categoria { get; set; }

        /// <summary>Identificador da pessoa que realizou a transação.</summary>
        public long PessoaId { get; set; }

        /// <summary>Pessoa que realizou a transação.</summary>
        public virtual Pessoa Pessoa { get; set; }
    }
}
