using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCCTrabalho3.Data;
using TCCTrabalho3.Models;
using System.Collections.Generic;
using System.Linq;

namespace TCCTrabalho3.Controllers
{
    [Authorize(Roles = "Admin")] // Todas as ações requerem que o usuário seja Admin
    public class VendaController1 : Controller
    {
        private readonly ApplicationDbContext _db;

        public VendaController1(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<VendasModel> vendas = _db.Vendas.ToList();
            return View(vendas);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            VendasModel venda = _db.Vendas.FirstOrDefault(x => x.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda); 
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            VendasModel venda = _db.Vendas.FirstOrDefault(x => x.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        [HttpPost]
        public IActionResult Cadastrar(VendasModel venda)
        {   
            if (ModelState.IsValid)
            {
                _db.Vendas.Add(venda);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Editar(VendasModel venda)
        {
            if (ModelState.IsValid)
            {
                _db.Vendas.Update(venda);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";
                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar edição!";
            return View(venda);
        }

        [HttpPost]
        public IActionResult Excluir(VendasModel venda)
        {
            if (venda == null)
            {
                return NotFound();
            }

            _db.Vendas.Remove(venda);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
