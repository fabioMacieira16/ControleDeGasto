namespace ApiDDD.Application.DTOs.Relatorio
{
    /// <summary>
    /// DTO com os totais financeiros de uma pessoa específica.
    /// saldo = total_receitas - total_despesas
    /// </summary>
    public class RelatorioPessoaDto
    {
        public long PessoaId { get; set; }
        public string NomePessoa { get; set; }
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }

        /// <summary>Saldo calculado: TotalReceitas - TotalDespesas.</summary>
        public decimal Saldo => TotalReceitas - TotalDespesas;
    }
}
