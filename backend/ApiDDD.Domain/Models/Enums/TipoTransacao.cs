namespace ApiDDD.Domain.Models.Enums
{
    /// <summary>
    /// Define o tipo de uma transação financeira.
    /// DESPESA: saída de dinheiro (gasto).
    /// RECEITA: entrada de dinheiro (renda).
    /// </summary>
    public enum TipoTransacao
    {
        DESPESA = 1,
        RECEITA = 2
    }
}
