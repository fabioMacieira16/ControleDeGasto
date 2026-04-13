namespace ApiDDD.Application.DTOs.Pessoa
{
    /// <summary>DTO para atualização dos dados de uma pessoa existente.</summary>
    public class UpdatePessoaDto
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
