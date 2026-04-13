using System.Collections.Generic;

namespace ApiDDD.Application.DTOs.Relatorio
{
    /// <summary>
    /// DTO com o relatório geral de todas as pessoas, incluindo totais consolidados.
    /// saldo_geral = total_receitas_geral - total_despesas_geral
    /// </summary>
    public class RelatorioGeralDto
    {
        public IEnumerable<RelatorioPessoaDto> Pessoas { get; set; }
        public decimal TotalReceitasGeral { get; set; }
        public decimal TotalDespesasGeral { get; set; }

        /// <summary>Saldo geral calculado: TotalReceitasGeral - TotalDespesasGeral.</summary>
        public decimal SaldoGeral => TotalReceitasGeral - TotalDespesasGeral;
    }
}
