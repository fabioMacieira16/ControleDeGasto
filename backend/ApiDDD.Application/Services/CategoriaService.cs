using ApiDDD.Application.DTOs.Categoria;
using ApiDDD.Application.Extensions;
using ApiDDD.Application.Interfaces;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;
using ApiDDD.Domain.Models.Validations;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDDD.Application.Services
{
    /// <summary>
    /// Serviço responsável pelo cadastro e listagem de Categorias.
    /// Categorias são utilizadas para classificar transações financeiras.
    /// </summary>
    public class CategoriaService : Service, ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        /// <summary>Retorna todas as categorias cadastradas.</summary>
        public async Task<OperationResult> ListarTodos()
        {
            var categorias = await _repository.GetAllAsync();
            var result = Mapper.Map<IEnumerable<ResponseCategoriaDto>>(categorias);
            return Success(result);
        }

        /// <summary>
        /// Cria uma nova categoria após validar os dados.
        /// Valida descrição (obrigatória, máx 400 chars).
        /// </summary>
        public async Task<OperationResult> Criar(CreateCategoriaDto dto)
        {
            var categoria = Mapper.Map<Categoria>(dto);

            // Valida a entidade antes de persistir
            if (!EntityIsValid(new CategoriaValidator(), categoria))
                return Error();

            await _repository.InsertAsync(categoria);
            return Success(categoria.Id);
        }
    }
}
