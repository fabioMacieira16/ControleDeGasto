using ApiDDD.Domain.Models.Enums;

namespace ApiDDD.Application.DTOs.Categoria
{
    /// <summary>DTO para criação de uma nova categoria.</summary>
    public class CreateCategoriaDto
    {
        public string Descricao { get; set; }
        public FinalidadeCategoria Finalidade { get; set; }
    }
}
