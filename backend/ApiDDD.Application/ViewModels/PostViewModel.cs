namespace ApiDDD.Application.ViewModels
{
    /// <summary>ViewModel de resposta para operações de criação, retornando o ID gerado.</summary>
    public class PostViewModel
    {
        public long Id { get; set; }

        public PostViewModel(long id) => Id = id;
    }
}
