using ApiDDD.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Interfaces;

/// <summary>
/// Interface de repositório para a entidade Transacao.
/// Além das operações CRUD base, expõe consulta por pessoa para suporte aos relatórios.
/// </summary>
public interface ITransacaoRepository : IRepository<Transacao>
{
    /// <summary>
    /// Retorna todas as transações de uma pessoa específica, incluindo a categoria associada.
    /// Utilizado para cálculo de totais e geração de relatórios.
    /// </summary>
    Task<IEnumerable<Transacao>> GetByPessoaIdAsync(long pessoaId);

    /// <summary>
    /// Retorna todas as transações de uma categoria específica.
    /// Utilizado para geração do relatório financeiro por categoria.
    /// </summary>
    Task<IEnumerable<Transacao>> GetByCategoriaIdAsync(long categoriaId);
}
