using ApiDDD.Application.Extensions;
using System.Threading.Tasks;

namespace ApiDDD.Application.Interfaces;

/// <summary>
/// Interface de serviço para operações com Categoria.
/// Apenas criação e listagem são suportadas conforme regra de negócio.
/// </summary>
public interface ICategoriaService
{
    Task<OperationResult> ListarTodos();
    Task<OperationResult> Criar(DTOs.Categoria.CreateCategoriaDto dto);
}
