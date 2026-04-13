using ApiDDD.Domain.Models;

namespace ApiDDD.Domain.Interfaces;

/// <summary>
/// Interface de repositório para a entidade Pessoa.
/// Herda todas as operações CRUD base do IRepository.
/// </summary>
public interface IPessoaRepository : IRepository<Pessoa>
{
}
