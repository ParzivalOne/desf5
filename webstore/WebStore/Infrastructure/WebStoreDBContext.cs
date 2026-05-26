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
    }
}
