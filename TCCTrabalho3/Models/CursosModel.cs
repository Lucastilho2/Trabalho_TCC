using System.ComponentModel.DataAnnotations;

namespace TCCTrabalho3.Models
{
    public class CursosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do curso é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
        public int Estoque { get; set; }
    }
    
}
