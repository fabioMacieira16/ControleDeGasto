using ApiDDD.Application.DTOs.Categoria;
using ApiDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiDDD.Api.Controllers
{
    /// <summary>
    /// Controller para gerenciamento de Categorias.
    /// Suporta apenas criação e listagem conforme regra de negócio.
    /// </summary>
    [Route("api/categorias")]
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        /// <summary>Lista todas as categorias cadastradas.</summary>
        [HttpGet]
        public async Task<IActionResult> ListarTodos()
            => CustomResponse(await _service.ListarTodos());

        /// <summary>Cria uma nova categoria com finalidade DESPESA, RECEITA ou AMBAS.</summary>
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateCategoriaDto dto)
            => CustomResponse(await _service.Criar(dto));
    }
}
