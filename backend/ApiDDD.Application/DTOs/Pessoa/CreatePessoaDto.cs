namespace ApiDDD.Application.DTOs.Pessoa
{
    /// <summary>DTO para criação de uma nova pessoa.</summary>
    public class CreatePessoaDto
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
