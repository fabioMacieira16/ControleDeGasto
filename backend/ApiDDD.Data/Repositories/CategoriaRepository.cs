using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;

namespace ApiDDD.Data.Repositories
{
    /// <summary>
    /// Repositório concreto para a entidade Categoria.
    /// Herda todas as operações CRUD da classe base Repository.
    /// </summary>
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(FactoryContext context) : base(context)
        {
        }
    }
}
