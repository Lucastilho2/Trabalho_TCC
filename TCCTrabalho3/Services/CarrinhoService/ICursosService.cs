using TCCTrabalho3.Models;

namespace TCCTrabalho3.Services.CarrinhoService
{
    public interface ICursosService
    {
        CursosModel GetCursoById(int id);
        IEnumerable<CursosModel> GetCursos();
    }
}
