using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TCCTrabalho3.Data;
using TCCTrabalho3.Models;

namespace TCCTrabalho3.Controllers
        {
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult AdicionarCurso()
        {
            return View();
        }


        public IActionResult Index()
        {
            // Recupera a lista de cursos
            var cursos = _context.Cursos.ToList();
            return View(cursos);
        }

        public IActionResult Details(int id)
        {
            // Recupera os detalhes de um curso específico pelo ID
            var curso = _context.Cursos.FirstOrDefault(c => c.Id == id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }
        [HttpPost]
        public IActionResult AdicionarCurso(CursosModel curso)
        {
            if (ModelState.IsValid) // Verifica se o modelo é válido
            {
                _context.Cursos.Add(curso); // Adiciona o curso ao contexto
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return RedirectToAction("Index"); // Redireciona para a lista de cursos
            }

            return View(curso); // Se o modelo não for válido, retorna a view com os dados preenchidos
        }

    }
}
