namespace TCCTrabalho3.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        public string NomeCustomizado { get; set; }
        public string Endereco { get; set; }
        public List<Carrinho> Items { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
