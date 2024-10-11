using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TCCTrabalho3.Data;
using TCCTrabalho3.Models;
using TCCTrabalho3.Services.CarrinhoService;

namespace TCCTrabalho3.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ApplicationDbContext _context;
          


        public CarrinhoController(ApplicationDbContext context)
        {
            _context = context;
        }   

        private Carrinho GetCarrinho()
        {
            var carrinho = HttpContext.Session.GetObject<Carrinho>("Carrinho") ?? new Carrinho();
            return carrinho;
        }
        public IActionResult Index()
        {
            var carrinho = GetCarrinho();
            return View(carrinho);
        }

        public IActionResult AdcionarParaCarrinho(int id)
        {
            try
            {
                var curso = _context.Cursos.FirstOrDefault(c => c.Id == id);
                if (curso == null)
                {
                    return NotFound();
                }

                // Tenta obter o carrinho da sessão
                var carrinho = HttpContext.Session.GetObject<Carrinho>("Carrinho") ?? new Carrinho();

                // Adiciona ou atualiza o item no carrinho
                var carrinhoItem = carrinho.Items.FirstOrDefault(c => c.CursoId == id);
                if (carrinhoItem == null)
                {
                    carrinho.Items.Add(new CarrinhoItem { CursoId = id, Quantidade = 1 });
                }
                else
                {
                    carrinhoItem.Quantidade++;
                }

                // Atualiza o carrinho na sessão
                HttpContext.Session.SetObject("Carrinho", carrinho);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log de erro ou manipulação de exceção
                // Você pode usar um logger para registrar o erro
                Console.WriteLine(ex.Message); // Para depuração

                return StatusCode(500, "Ocorreu um erro ao adicionar o curso ao carrinho.");
            }
        }
        public IActionResult RemoverDoCarrinho(int id)
        {
            var carrinho = GetCarrinho();
            var carrinhoItem = carrinho.Items.FirstOrDefault(c => c.CursoId == id);
            if (carrinhoItem != null)
            {
                carrinho.Items.Remove(carrinhoItem);
                HttpContext.Session.SetObject("Carrinho", carrinho);
            }
            return RedirectToAction("Index");
        }
    }
}
