using System;
using TCCTrabalho3.Data;
using TCCTrabalho3.Models;

namespace TCCTrabalho3.Services.CarrinhoService
{
    public class CursosService : ICursosService
    {
        private readonly ApplicationDbContext _context;

        public CursosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public CursosModel GetCursoById(int id)
        {
            return _context.Cursos.Find(id); // Busca o curso pelo ID
        }

        public IEnumerable<CursosModel> GetCursos()
        {
            return _context.Cursos.ToList(); // Retorna todos os cursos
        }
    }
}
