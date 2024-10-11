using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TCCTrabalho3.Models;

namespace TCCTrabalho3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
                 public DbSet<VendasModel> Vendas { get; set; }
                 public DbSet<CursosModel> Cursos { get; set; }
                 public DbSet<Pedidos> Pedidos { get; set; }
                 public DbSet<Carrinho> Carrinhos { get; set; }
                 public DbSet<CarrinhoItem> CarrinhosItems { get; set; }

    }
}   
