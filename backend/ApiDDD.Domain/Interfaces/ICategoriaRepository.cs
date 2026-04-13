using ApiDDD.Domain.Models;

namespace ApiDDD.Domain.Interfaces;

/// <summary>
/// Interface de repositório para a entidade Categoria.
/// Herda todas as operações CRUD base do IRepository.
/// </summary>
public interface ICategoriaRepository : IRepository<Categoria>
{
}
