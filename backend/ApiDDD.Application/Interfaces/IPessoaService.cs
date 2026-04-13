using ApiDDD.Application.Extensions;
using System.Threading.Tasks;

namespace ApiDDD.Application.Interfaces;

/// <summary>
/// Interface de serviço para operações com Pessoa.
/// Define o contrato CRUD completo.
/// </summary>
public interface IPessoaService
{
    Task<OperationResult> ListarTodos();
    Task<OperationResult> BuscarPorId(long id);
    Task<OperationResult> Criar(DTOs.Pessoa.CreatePessoaDto dto);
    Task<OperationResult> Atualizar(long id, DTOs.Pessoa.UpdatePessoaDto dto);
    Task<OperationResult> Deletar(long id);
}
