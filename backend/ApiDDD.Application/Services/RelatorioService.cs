using ApiDDD.Application.DTOs.Relatorio;
using ApiDDD.Application.Extensions;
using ApiDDD.Application.Interfaces;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models.Enums;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDDD.Application.Services
{
    /// <summary>
    /// Serviço responsável pela geração de relatórios financeiros.
    /// Agrega transações por pessoa e por categoria, calculando receitas, despesas e saldo.
    /// </summary>
    public class RelatorioService : Service, IRelatorioService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ITransacaoRepository _transacaoRepository;

        public RelatorioService(
            IPessoaRepository pessoaRepository,
            ICategoriaRepository categoriaRepository,
            ITransacaoRepository transacaoRepository,
            IMapper mapper) : base(mapper)
        {
            _pessoaRepository = pessoaRepository;
            _categoriaRepository = categoriaRepository;
            _transacaoRepository = transacaoRepository;
        }

        /// <summary>
        /// Gera o relatório financeiro completo:
        /// - Por pessoa: total de receitas, despesas e saldo individual.
        /// - Totais gerais consolidados de todas as pessoas.
        /// Saldo = total_receitas - total_despesas.
        /// </summary>
        public async Task<OperationResult> GetRelatoriosPessoas()
        {
            var pessoas = await _pessoaRepository.GetAllAsync();
            var relatorioPessoas = new List<RelatorioPessoaDto>();

            foreach (var pessoa in pessoas)
            {
                // Busca todas as transações vinculadas à pessoa
                var transacoes = (await _transacaoRepository.GetByPessoaIdAsync(pessoa.Id)).ToList();

                // Calcula totais separando por tipo
                var totalReceitas = transacoes
                    .Where(t => t.Tipo == TipoTransacao.RECEITA)
                    .Sum(t => t.Valor);

                var totalDespesas = transacoes
                    .Where(t => t.Tipo == TipoTransacao.DESPESA)
                    .Sum(t => t.Valor);

                relatorioPessoas.Add(new RelatorioPessoaDto
                {
                    PessoaId = pessoa.Id,
                    NomePessoa = pessoa.Nome,
                    TotalReceitas = totalReceitas,
                    TotalDespesas = totalDespesas
                    // Saldo é calculado automaticamente pela propriedade derivada
                });
            }

            // Consolida os totais gerais somando os totais individuais
            var relatorioGeral = new RelatorioGeralDto
            {
                Pessoas = relatorioPessoas,
                TotalReceitasGeral = relatorioPessoas.Sum(p => p.TotalReceitas),
                TotalDespesasGeral = relatorioPessoas.Sum(p => p.TotalDespesas)
                // SaldoGeral é calculado automaticamente pela propriedade derivada
            };

            return Success(relatorioGeral);
        }

        /// <summary>
        /// Gera o relatório financeiro por categoria:
        /// - Para cada categoria: total de receitas, despesas e saldo individual.
        /// - Totais gerais consolidados de todas as categorias.
        /// Saldo = total_receitas - total_despesas.
        /// </summary>
        public async Task<OperationResult> GetRelatoriosCategorias()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            var relatorioCategorias = new List<RelatorioCategoriaDto>();

            foreach (var categoria in categorias)
            {
                // Busca todas as transações vinculadas à categoria
                var transacoes = (await _transacaoRepository.GetByCategoriaIdAsync(categoria.Id)).ToList();

                // Calcula totais separando por tipo
                var totalReceitas = transacoes
                    .Where(t => t.Tipo == TipoTransacao.RECEITA)
                    .Sum(t => t.Valor);

                var totalDespesas = transacoes
                    .Where(t => t.Tipo == TipoTransacao.DESPESA)
                    .Sum(t => t.Valor);

                relatorioCategorias.Add(new RelatorioCategoriaDto
                {
                    CategoriaId = categoria.Id,
                    DescricaoCategoria = categoria.Descricao,
                    TotalReceitas = totalReceitas,
                    TotalDespesas = totalDespesas
                    // Saldo é calculado automaticamente pela propriedade derivada
                });
            }

            // Consolida os totais gerais somando os totais individuais de cada categoria
            var relatorioGeral = new RelatorioGeralCategoriaDto
            {
                Categorias = relatorioCategorias,
                TotalReceitasGeral = relatorioCategorias.Sum(c => c.TotalReceitas),
                TotalDespesasGeral = relatorioCategorias.Sum(c => c.TotalDespesas)
                // SaldoGeral é calculado automaticamente pela propriedade derivada
            };

            return Success(relatorioGeral);
        }
    }
}
