using ApiDDD.Application.DTOs.Pessoa;
using ApiDDD.Application.Extensions;
using ApiDDD.Application.Interfaces;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;
using ApiDDD.Domain.Models.Validations;
using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ApiDDD.Application.Services
{
    /// <summary>
    /// Serviço responsável pelas operações de CRUD de Pessoa.
    /// Aplica validações de domínio antes de persistir os dados.
    /// </summary>
    public class PessoaService : Service, IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        /// <summary>Retorna todas as pessoas cadastradas.</summary>
        public async Task<OperationResult> ListarTodos()
        {
            var pessoas = await _repository.GetAllAsync();
            var result = Mapper.Map<IEnumerable<ResponsePessoaDto>>(pessoas);
            return Success(result);
        }

        /// <summary>Busca uma pessoa pelo seu ID. Retorna 404 se não encontrada.</summary>
        public async Task<OperationResult> BuscarPorId(long id)
        {
            var pessoa = await _repository.GetByIdAsync(id);
            if (pessoa == null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(Mapper.Map<ResponsePessoaDto>(pessoa));
        }

        /// <summary>
        /// Cria uma nova pessoa após validar os dados.
        /// Valida nome (máx 200 chars) e idade (>= 0).
        /// </summary>
        public async Task<OperationResult> Criar(CreatePessoaDto dto)
        {
            var pessoa = Mapper.Map<Pessoa>(dto);

            // Valida a entidade antes de persistir
            if (!EntityIsValid(new PessoaValidator(), pessoa))
                return Error();

            await _repository.InsertAsync(pessoa);
            return Success(pessoa.Id);
        }

        /// <summary>
        /// Atualiza os dados de uma pessoa existente.
        /// Retorna 404 se a pessoa não for encontrada.
        /// </summary>
        public async Task<OperationResult> Atualizar(long id, UpdatePessoaDto dto)
        {
            var pessoa = await _repository.GetByIdAsync(id);
            if (pessoa == null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            // Atualiza somente os campos fornecidos
            pessoa.Nome = dto.Nome;
            pessoa.Idade = dto.Idade;

            // Valida a entidade atualizada antes de persistir
            if (!EntityIsValid(new PessoaValidator(), pessoa))
                return Error();

            await _repository.UpdateAsync(pessoa);
            return Success(Mapper.Map<ResponsePessoaDto>(pessoa));
        }

        /// <summary>
        /// Deleta uma pessoa e suas transações vinculadas (cascade configurado no banco).
        /// Retorna 404 se a pessoa não for encontrada.
        /// </summary>
        public async Task<OperationResult> Deletar(long id)
        {
            var pessoa = await _repository.GetByIdAsync(id);
            if (pessoa == null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            await _repository.DeleteAsync(pessoa);
            return Success();
        }
    }
}
