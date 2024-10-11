namespace TCCTrabalho3.Models
{
    public class Carrinho
    {
        public int CarrinhoId { get; set; }
        public string UsuarioId { get; set; } // Para identificar o usuário
        public List<CarrinhoItem> Items { get; set; } = new List<CarrinhoItem>();

    }


}

