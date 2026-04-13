using ApiDDD.Application.DTOs.Categoria;
using ApiDDD.Application.DTOs.Pessoa;
using ApiDDD.Application.DTOs.Transacao;
using ApiDDD.Domain.Models;
using AutoMapper;

namespace ApiDDD.Application.Profiles
{
    /// <summary>
    /// Configuração dos mapeamentos AutoMapper entre entidades do domínio e DTOs.
    /// </summary>
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Pessoa
            CreateMap<CreatePessoaDto, Pessoa>();
            CreateMap<UpdatePessoaDto, Pessoa>();
            CreateMap<Pessoa, ResponsePessoaDto>();

            // Categoria
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<Categoria, ResponseCategoriaDto>();

            // Transacao — mapeia as propriedades de navegação para os campos de resposta
            CreateMap<CreateTransacaoDto, Transacao>();
            CreateMap<Transacao, ResponseTransacaoDto>()
                .ForMember(dest => dest.CategoriaDescricao, opt => opt.MapFrom(src => src.Categoria != null ? src.Categoria.Descricao : null))
                .ForMember(dest => dest.PessoaNome, opt => opt.MapFrom(src => src.Pessoa != null ? src.Pessoa.Nome : null));
        }
    }
}