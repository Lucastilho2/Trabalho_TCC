using System.ComponentModel.DataAnnotations;

namespace TCCTrabalho3.Models
{
    public class VendasModel
    {      
            public int Id { get; set; }
            [Required(ErrorMessage = "Digite o nome do Recebedor!")]
            public string Recebedor { get; set; }
            [Required(ErrorMessage = "Digite o nome do Fornecedor!")]

            public string Fornecedor { get; set; }
            [Required(ErrorMessage = "Digite o nome do Curso!")]

            public string CursoVendido { get; set; }
            public DateTime dataUltimaAtualizacao { get; set; } = DateTime.Now;
        
    }
}
