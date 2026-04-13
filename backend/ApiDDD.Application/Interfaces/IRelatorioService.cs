using ApiDDD.Application.Extensions;
using System.Threading.Tasks;

namespace ApiDDD.Application.Interfaces;

/// <summary>
/// Interface de serviço para geração de relatórios financeiros.
/// </summary>
public interface IRelatorioService
{
    /// <summary>
    /// Retorna o relatório com totais de receitas, despesas e saldo por pessoa,
    /// mais os totais gerais consolidados.
    /// </summary>
    Task<OperationResult> GetRelatoriosPessoas();

    /// <summary>
    /// Retorna o relatório com totais de receitas, despesas e saldo por categoria,
    /// mais os totais gerais consolidados.
    /// </summary>
    Task<OperationResult> GetRelatoriosCategorias();
}
