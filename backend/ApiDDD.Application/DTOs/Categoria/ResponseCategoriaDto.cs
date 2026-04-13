using ApiDDD.Domain.Models.Enums;

namespace ApiDDD.Application.DTOs.Categoria
{
    /// <summary>DTO de resposta com os dados de uma categoria.</summary>
    public class ResponseCategoriaDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public FinalidadeCategoria Finalidade { get; set; }
    }
}
