using ApiDDD.Application.DTOs.Transacao;
using ApiDDD.Application.Extensions;
using ApiDDD.Application.Interfaces;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;
using ApiDDD.Domain.Models.Enums;
using ApiDDD.Domain.Models.Validations;
using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ApiDDD.Application.Services
{
    /// <summary>
    /// Serviço responsável pelo registro e listagem de Transações financeiras.
    /// Aplica todas as regras de negócio antes de persistir.
    /// </summary>
    public class TransacaoService : Service, ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public TransacaoService(
            ITransacaoRepository transacaoRepository,
            IPessoaRepository pessoaRepository,
            ICategoriaRepository categoriaRepository,
            IMapper mapper) : base(mapper)
        {
            _transacaoRepository = transacaoRepository;
            _pessoaRepository = pessoaRepository;
            _categoriaRepository = categoriaRepository;
        }

        /// <summary>Retorna todas as transações cadastradas, incluindo dados de pessoa e categoria.</summary>
        public async Task<OperationResult> ListarTodos()
        {
            var transacoes = await _transacaoRepository.GetAllAsync();
            var result = Mapper.Map<IEnumerable<ResponseTransacaoDto>>(transacoes);
            return Success(result);
        }

        /// <summary>
        /// Cria uma nova transação aplicando as seguintes regras de negócio:
        /// 1. O valor deve ser positivo (validado pelo TransacaoValidator).
        /// 2. Menores de 18 anos só podem registrar DESPESAS.
        /// 3. A categoria deve ser compatível com o tipo da transação.
        /// </summary>
        public async Task<OperationResult> Criar(CreateTransacaoDto dto)
        {
            // Verifica se a pessoa existe
            var pessoa = await _pessoaRepository.GetByIdAsync(dto.PessoaId);
            if (pessoa == null)
                return Error("Pessoa não encontrada.", HttpStatusCode.NotFound);

            // Verifica se a categoria existe
            var categoria = await _categoriaRepository.GetByIdAsync(dto.CategoriaId);
            if (categoria == null)
                return Error("Categoria não encontrada.", HttpStatusCode.NotFound);

            // Regra de negócio: menor de 18 anos só pode registrar DESPESA
            if (pessoa.Idade < 18 && dto.Tipo == TipoTransacao.RECEITA)
                return Error("Pessoas menores de 18 anos só podem registrar transações do tipo DESPESA.");

            // Regra de negócio: categoria deve ser compatível com o tipo da transação
            if (dto.Tipo == TipoTransacao.DESPESA && categoria.Finalidade == FinalidadeCategoria.RECEITA)
                return Error("Categoria de finalidade RECEITA não pode ser usada em transações do tipo DESPESA.");

            if (dto.Tipo == TipoTransacao.RECEITA && categoria.Finalidade == FinalidadeCategoria.DESPESA)
                return Error("Categoria de finalidade DESPESA não pode ser usada em transações do tipo RECEITA.");

            var transacao = Mapper.Map<Transacao>(dto);

            // Valida estrutura básica da entidade (valor positivo, campos obrigatórios)
            if (!EntityIsValid(new TransacaoValidator(), transacao))
                return Error();

            await _transacaoRepository.InsertAsync(transacao);
            return Success(transacao.Id);
        }
    }
}
