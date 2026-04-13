using ApiDDD.Application.DTOs.Pessoa;
using ApiDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiDDD.Api.Controllers
{
    /// <summary>
    /// Controller para gerenciamento de Pessoas.
    /// Expõe operações de CRUD completo.
    /// </summary>
    [Route("api/pessoas")]
    public class PessoaController : ApiController
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        /// <summary>Lista todas as pessoas cadastradas.</summary>
        [HttpGet]
        public async Task<IActionResult> ListarTodos()
            => CustomResponse(await _service.ListarTodos());

        /// <summary>Busca uma pessoa pelo ID.</summary>
        [HttpGet("{id:long}")]
        public async Task<IActionResult> BuscarPorId(long id)
            => CustomResponse(await _service.BuscarPorId(id));

        /// <summary>Cria uma nova pessoa.</summary>
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreatePessoaDto dto)
            => CustomResponse(await _service.Criar(dto));

        /// <summary>Atualiza os dados de uma pessoa existente.</summary>
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Atualizar(long id, [FromBody] UpdatePessoaDto dto)
            => CustomResponse(await _service.Atualizar(id, dto));

        /// <summary>
        /// Deleta uma pessoa e todas as suas transações vinculadas (cascade delete).
        /// </summary>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Deletar(long id)
            => CustomResponse(await _service.Deletar(id));
    }
}
