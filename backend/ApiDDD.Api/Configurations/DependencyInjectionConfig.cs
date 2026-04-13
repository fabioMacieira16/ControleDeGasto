using Microsoft.Extensions.DependencyInjection;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Application.Interfaces;
using ApiDDD.Application.Services;
using ApiDDD.Data.Repositories;

namespace ApiDDD.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Registra todos os repositórios e serviços da aplicação ControleGastos.
        /// Utiliza tempo de vida Scoped para garantir uma instância por requisição HTTP.
        /// </summary>
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            // Repositórios
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();

            // Serviços
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<IRelatorioService, RelatorioService>();
        }
    }
}
