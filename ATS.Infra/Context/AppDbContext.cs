using ATS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS.Infra.Context
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<EnderecoUsuario> EnderecoUsuario { get; set; }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Pedido> Pedido { get; set; }
    }
}