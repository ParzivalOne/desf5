using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Infrastructure
{
    public class WebStoreDBContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        public WebStoreDBContext(DbContextOptions<WebStoreDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Nome)
                .HasDatabaseName("IX_Clientes_Nome");

            modelBuilder.Entity<Produto>()
                .HasIndex(p => p.Nome)
                .HasDatabaseName("IX_Produtos_Nome");

            base.OnModelCreating(modelBuilder);
        }
    }
}
