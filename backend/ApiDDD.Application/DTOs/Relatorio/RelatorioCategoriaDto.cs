namespace ApiDDD.Application.DTOs.Relatorio;

/// <summary>
/// DTO com os totais financeiros de uma categoria específica.
/// Saldo = TotalReceitas - TotalDespesas.
/// </summary>
public class RelatorioCategoriaDto
{
    public long CategoriaId { get; set; }
    public string DescricaoCategoria { get; set; }
    public decimal TotalReceitas { get; set; }
    public decimal TotalDespesas { get; set; }

    /// <summary>Saldo calculado: TotalReceitas - TotalDespesas.</summary>
    public decimal Saldo => TotalReceitas - TotalDespesas;
}
