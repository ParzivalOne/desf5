using Microsoft.EntityFrameworkCore;
using WebStore.DTOs;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Repositories.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Repositories
{
    public class PedidoRepository(WebStoreDBContext dBContext) : IPedidoRepository
    {
        public async Task<Pedido> CreatePedidoAsync(PedidoCreateInputDto pedidoCreate, CancellationToken cancellationToken = default)
        {
            var pedido = Pedido.MapFrom(pedidoCreate);
            pedido.Id = Guid.NewGuid();
            dBContext.Pedidos.Add(pedido);
            await dBContext.SaveChangesAsync(cancellationToken);
            return pedido;
        }

        public async Task<Pedido?> GetPedidoByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dBContext.Pedidos
                .Include(pedido => pedido.Cliente)
                .Include(pedido => pedido.ItensPedido)
                .AsNoTracking().
                FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<Pedido> UpdatePedidoAsync(Guid id, PedidoUpdateInputDto updatedPedido, CancellationToken cancellationToken = default)
        {
            var existingPedido = await dBContext.Pedidos.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            if (existingPedido == null)
            {
                throw new KeyNotFoundException($"Pedido with ID {id} not found.");
            }

            existingPedido.EnderecoEntrega = updatedPedido.EnderecoEntrega ?? existingPedido.EnderecoEntrega;
            existingPedido.Status = updatedPedido.Status ?? existingPedido.Status;

            await dBContext.SaveChangesAsync(cancellationToken);
            return existingPedido;
        }

        public async Task DeletePedidoAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var existingPedido = await dBContext.Pedidos.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            if (existingPedido == null)
            {
                throw new KeyNotFoundException($"Pedido with ID {id} not found.");
            }
            dBContext.Pedidos.Remove(existingPedido);
            await dBContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Pedido>> GetAllPedidosAsync(CancellationToken cancellationToken = default)
        {
            return await dBContext.Pedidos.ToListAsync(cancellationToken);
        }

        public async Task<Pedido> AddItemAsync(Guid pedidoId, ItemPedidoCreateInputDto itemPedidoCreate, CancellationToken cancellationToken)
        {
            var existingPedido = await dBContext.Pedidos.FirstOrDefaultAsync(entity => entity.Id == pedidoId, cancellationToken);
            if (existingPedido == null)
            {
                throw new KeyNotFoundException($"Pedido with ID {pedidoId} not found.");
            }
            var itemPedido = new ItemPedido
            {
                Id = Guid.NewGuid(),
                PedidoId = pedidoId,
                ProdutoId = itemPedidoCreate.ProdutoId,
                Quantidade = itemPedidoCreate.Quantidade
            };
            dBContext.ItensPedido.Add(itemPedido);
            await dBContext.SaveChangesAsync(cancellationToken);
            return existingPedido;
        }

        public async Task<Pedido> RemoveItemAsync(Guid pedidoId, Guid itemPedidoId, CancellationToken cancellationToken = default)
        {
            var existingPedido = await dBContext.Pedidos.FirstOrDefaultAsync(entity => entity.Id == pedidoId, cancellationToken);
            if (existingPedido == null)
            {
                throw new KeyNotFoundException($"Pedido with ID {pedidoId} not found.");
            }
            var existingItemPedido = await dBContext.ItensPedido.FirstOrDefaultAsync(entity => entity.Id == itemPedidoId && entity.PedidoId == pedidoId, cancellationToken);
            if (existingItemPedido == null)
            {
                throw new KeyNotFoundException($"ItemPedido with ID {itemPedidoId} not found in Pedido {pedidoId}.");
            }
            dBContext.ItensPedido.Remove(existingItemPedido);
            await dBContext.SaveChangesAsync(cancellationToken);
            return existingPedido;
        }

        public async Task<Pedido> UpdateItemAsync(Guid pedidoId, Guid itemPedidoId, ItemPedidoUpdateInputDto updatedItemPedido, CancellationToken cancellationToken = default)
        {
            var existingPedido = await dBContext.Pedidos.FirstOrDefaultAsync(entity => entity.Id == pedidoId, cancellationToken);
            if (existingPedido == null)
            {
                throw new KeyNotFoundException($"Pedido with ID {pedidoId} not found.");
            }
            var existingItemPedido = await dBContext.ItensPedido.FirstOrDefaultAsync(entity => entity.Id == itemPedidoId && entity.PedidoId == pedidoId, cancellationToken);
            if (existingItemPedido == null)
            {
                throw new KeyNotFoundException($"ItemPedido with ID {itemPedidoId} not found in Pedido {pedidoId}.");
            }
            existingItemPedido.ProdutoId = updatedItemPedido.ProdutoId ?? existingItemPedido.ProdutoId;
            existingItemPedido.Quantidade = updatedItemPedido.Quantidade ?? existingItemPedido.Quantidade;
            await dBContext.SaveChangesAsync(cancellationToken);
            return existingPedido;
        }

        public async Task<long> GetPedidosCountAsync(CancellationToken cancellationToken = default)
        {
            return await dBContext.Pedidos.LongCountAsync(cancellationToken);
        }
    }
}
