using ApiDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiDDD.Api.Controllers
{
    /// <summary>
    /// Controller para consulta de relatórios financeiros.
    /// Expõe endpoints de agregação de dados por pessoa.
    /// </summary>
    [Route("api/relatorios")]
    public class RelatorioController : ApiController
    {
        private readonly IRelatorioService _service;

        public RelatorioController(IRelatorioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna o relatório financeiro por pessoa, com:
        /// - total_receitas, total_despesas e saldo de cada pessoa.
        /// - total_receitas_geral, total_despesas_geral e saldo_geral consolidados.
        /// </summary>
        [HttpGet("pessoas")]
        public async Task<IActionResult> GetRelatoriosPessoas()
            => CustomResponse(await _service.GetRelatoriosPessoas());

        /// <summary>
        /// Retorna o relatório financeiro por categoria, com:
        /// - total_receitas, total_despesas e saldo de cada categoria.
        /// - total_receitas_geral, total_despesas_geral e saldo_geral consolidados.
        /// </summary>
        [HttpGet("categorias")]
        public async Task<IActionResult> GetRelatoriosCategorias()
            => CustomResponse(await _service.GetRelatoriosCategorias());
    }
}
