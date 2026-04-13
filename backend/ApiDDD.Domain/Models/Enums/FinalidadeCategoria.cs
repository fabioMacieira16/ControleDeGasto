namespace ApiDDD.Domain.Models.Enums
{
    /// <summary>
    /// Define a finalidade de uma categoria de transação.
    /// DESPESA: categoria usada apenas para despesas.
    /// RECEITA: categoria usada apenas para receitas.
    /// AMBAS: categoria compatível com qualquer tipo de transação.
    /// </summary>
    public enum FinalidadeCategoria
    {
        DESPESA = 1,
        RECEITA = 2,
        AMBAS = 3
    }
}
