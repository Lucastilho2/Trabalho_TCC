using Microsoft.EntityFrameworkCore;
using System;
using TCCTrabalho3.Data;
using TCCTrabalho3.Models;

namespace TCCTrabalho3.Services.CarrinhoService
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ApplicationDbContext _context;

        public CarrinhoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarItem(int carrinhoId, CursosModel curso, int quantidade)
        {
            var carrinhoItem = _context.CarrinhosItems
                .SingleOrDefault(ci => ci.CarrinhoId == carrinhoId && ci.CursoId == curso.Id);

            if (carrinhoItem == null)
            {
                carrinhoItem = new CarrinhoItem
                {
                    CarrinhoId = carrinhoId,
                    CursoId = curso.Id,
                    Quantidade = quantidade
                };
                _context.CarrinhosItems.Add(carrinhoItem);
            }
            else
            {
                carrinhoItem.Quantidade += quantidade;
            }

            _context.SaveChanges();
        }

        public Carrinho GetCarrinho(int carrinhoId)
        {
            return _context.Carrinhos
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Cursos)
                .SingleOrDefault(c => c.CarrinhoId == carrinhoId);
        }

        public void RemoverItem(int carrinhoItemId)
        {
            var item = _context.CarrinhosItems.Find(carrinhoItemId);
            if (item != null)
            {
                _context.CarrinhosItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
