using ApiDDD.Domain.Models.Enums;

namespace ApiDDD.Application.DTOs.Transacao
{
    /// <summary>DTO de resposta com os dados de uma transação, incluindo informações de pessoa e categoria.</summary>
    public class ResponseTransacaoDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public long CategoriaId { get; set; }
        public string CategoriaDescricao { get; set; }
        public long PessoaId { get; set; }
        public string PessoaNome { get; set; }
    }
}
