using TCCTrabalho3.Models;
using TCCTrabalho3.Services;

namespace TCCTrabalho3.Services.CarrinhoService
{
    public interface ICarrinhoService
    {
        void AdicionarItem(int carrinhoId, CursosModel curso, int quantidade);
        Carrinho GetCarrinho(int carrinhoId);
        void RemoverItem(int carrinhoItemId);
    }
}
