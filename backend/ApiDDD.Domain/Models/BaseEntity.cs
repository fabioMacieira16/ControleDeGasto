using System.ComponentModel.DataAnnotations;

namespace ApiDDD.Domain.Models
{
    /// <summary>
    /// Classe base para todas as entidades do domínio.
    /// Define o identificador único compartilhado por todas as entidades.
    /// </summary>
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}