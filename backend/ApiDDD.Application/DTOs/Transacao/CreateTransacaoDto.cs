using ApiDDD.Domain.Models.Enums;

namespace ApiDDD.Application.DTOs.Transacao
{
    /// <summary>DTO para criação de uma nova transação financeira.</summary>
    public class CreateTransacaoDto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public long CategoriaId { get; set; }
        public long PessoaId { get; set; }
    }
}
