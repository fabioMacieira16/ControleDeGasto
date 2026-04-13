using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDDD.Data.Repositories
{
    /// <summary>
    /// Repositório concreto para a entidade Transacao.
    /// Além do CRUD base, fornece consulta por pessoa com carregamento das entidades relacionadas.
    /// </summary>
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(FactoryContext context) : base(context)
        {
        }

        /// <summary>
        /// Retorna todas as transações de uma pessoa, incluindo Categoria e Pessoa
        /// para que os dados de nome/descrição fiquem disponíveis no mapeamento.
        /// </summary>
        public async Task<IEnumerable<Transacao>> GetByPessoaIdAsync(long pessoaId)
        {
            return await _context.Transacoes
                .AsNoTracking()
                .Include(t => t.Categoria)
                .Include(t => t.Pessoa)
                .Where(t => t.PessoaId == pessoaId)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna todas as transações de uma categoria, incluindo Categoria e Pessoa.
        /// Utilizado para geração do relatório financeiro por categoria.
        /// </summary>
        public async Task<IEnumerable<Transacao>> GetByCategoriaIdAsync(long categoriaId)
        {
            return await _context.Transacoes
                .AsNoTracking()
                .Include(t => t.Categoria)
                .Include(t => t.Pessoa)
                .Where(t => t.CategoriaId == categoriaId)
                .ToListAsync();
        }

        /// <summary>
        /// Sobrescreve GetAllAsync para incluir os dados de Categoria e Pessoa
        /// nos resultados retornados pela listagem geral.
        /// </summary>
        public override async Task<IEnumerable<Transacao>> GetAllAsync()
        {
            return await _context.Transacoes
                .AsNoTracking()
                .Include(t => t.Categoria)
                .Include(t => t.Pessoa)
                .ToListAsync();
        }
    }
}
