using ApiDDD.Application.Extensions;
using System.Threading.Tasks;

namespace ApiDDD.Application.Interfaces;

/// <summary>
/// Interface de serviço para operações com Transacao.
/// Criação e listagem de transações com validações de regra de negócio.
/// </summary>
public interface ITransacaoService
{
    Task<OperationResult> ListarTodos();
    Task<OperationResult> Criar(DTOs.Transacao.CreateTransacaoDto dto);
}
