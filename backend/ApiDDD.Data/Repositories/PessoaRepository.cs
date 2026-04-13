using ApiDDD.Data.Repositories;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;

namespace ApiDDD.Data.Repositories
{
    /// <summary>
    /// Repositório concreto para a entidade Pessoa.
    /// Herda todas as operações CRUD da classe base Repository.
    /// </summary>
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(FactoryContext context) : base(context)
        {
        }
    }
}
