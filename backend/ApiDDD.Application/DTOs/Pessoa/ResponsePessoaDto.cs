namespace ApiDDD.Application.DTOs.Pessoa
{
    /// <summary>DTO de resposta com os dados de uma pessoa.</summary>
    public class ResponsePessoaDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
