using Microsoft.EntityFrameworkCore;
using WebStore.DTOs;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Repositories.Interfaces;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class PedidoService(IPedidoRepository repository) : IPedidoService
    {
        public async Task<Pedido> CreatePedidoAsync(PedidoCreateInputDto pedidoCreate, CancellationToken cancellationToken = default)
            => await repository.CreatePedidoAsync(pedidoCreate, cancellationToken);

        public async Task<Pedido?> GetPedidoByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await repository.GetPedidoByIdAsync(id, cancellationToken);

        public async Task<Pedido> UpdatePedidoAsync(Guid id, PedidoUpdateInputDto updatedPedido, CancellationToken cancellationToken = default)
            => await repository.UpdatePedidoAsync(id, updatedPedido, cancellationToken);

        public async Task DeletePedidoAsync(Guid id, CancellationToken cancellationToken = default)
            => await repository.DeletePedidoAsync(id, cancellationToken);

        public async Task<List<Pedido>> GetAllPedidosAsync(CancellationToken cancellationToken = default)
            => await repository.GetAllPedidosAsync(cancellationToken);

        public async Task<Pedido> AddItemAsync(Guid pedidoId, ItemPedidoCreateInputDto itemPedidoCreate, CancellationToken cancellationToken)
            => await repository.AddItemAsync(pedidoId, itemPedidoCreate, cancellationToken);

        public async Task<Pedido> RemoveItemAsync(Guid pedidoId, Guid itemPedidoId, CancellationToken cancellationToken = default)
            => await repository.RemoveItemAsync(pedidoId, itemPedidoId, cancellationToken);

        public async Task<Pedido> UpdateItemAsync(Guid pedidoId, Guid itemPedidoId, ItemPedidoUpdateInputDto updatedItemPedido, CancellationToken cancellationToken = default)
            => await repository.UpdateItemAsync(pedidoId, itemPedidoId, updatedItemPedido, cancellationToken);

        public async Task<long> GetPedidosCountAsync(CancellationToken cancellationToken = default)
            => await repository.GetPedidosCountAsync(cancellationToken);
    }
}
