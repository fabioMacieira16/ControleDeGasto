using System.Collections.Generic;

namespace ApiDDD.Application.DTOs.Relatorio;

/// <summary>
/// DTO com o relatório geral de todas as categorias, incluindo totais consolidados.
/// SaldoGeral = TotalReceitasGeral - TotalDespesasGeral.
/// </summary>
public class RelatorioGeralCategoriaDto
{
    public IEnumerable<RelatorioCategoriaDto> Categorias { get; set; }
    public decimal TotalReceitasGeral { get; set; }
    public decimal TotalDespesasGeral { get; set; }

    /// <summary>Saldo geral calculado: TotalReceitasGeral - TotalDespesasGeral.</summary>
    public decimal SaldoGeral => TotalReceitasGeral - TotalDespesasGeral;
}
