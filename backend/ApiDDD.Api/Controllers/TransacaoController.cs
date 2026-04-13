using ApiDDD.Application.DTOs.Transacao;
using ApiDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiDDD.Api.Controllers
{
    /// <summary>
    /// Controller para gerenciamento de Transações financeiras.
    /// Validações de regra de negócio são aplicadas na camada de serviço.
    /// </summary>
    [Route("api/transacoes")]
    public class TransacaoController : ApiController
    {
        private readonly ITransacaoService _service;

        public TransacaoController(ITransacaoService service)
        {
            _service = service;
        }

        /// <summary>Lista todas as transações cadastradas.</summary>
        [HttpGet]
        public async Task<IActionResult> ListarTodos()
            => CustomResponse(await _service.ListarTodos());

        /// <summary>
        /// Cria uma nova transação aplicando as regras de negócio:
        /// - Valor deve ser positivo.
        /// - Menores de 18 anos só podem registrar DESPESAS.
        /// - Categoria deve ser compatível com o tipo da transação.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateTransacaoDto dto)
            => CustomResponse(await _service.Criar(dto));
    }
}
