namespace TCCTrabalho3.Models
{
    public class CarrinhoItem
    {
        public int CarrinhoItemId { get; set; } 
        public int CursoId { get; set; } // Id do produto
        public int Quantidade { get; set; } // Quantidade do produto
        public int CarrinhoId { get; set; }

        public virtual CursosModel Cursos { get; set; } // Navegação para Product
        public virtual Carrinho Carrinho { get; set; } // Navegação para Carrinho
    }
}
