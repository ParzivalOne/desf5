using WebStore.DTOs;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> AddItemAsync(Guid pedidoId, ItemPedidoCreateInputDto itemPedidoCreate, CancellationToken cancellationToken = default);
        Task<Pedido> CreatePedidoAsync(PedidoCreateInputDto pedidoCreate, CancellationToken cancellationToken = default);
        Task DeletePedidoAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Pedido>> GetAllPedidosAsync(CancellationToken cancellationToken = default);
        Task<Pedido?> GetPedidoByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Pedido> RemoveItemAsync(Guid pedidoId, Guid itemPedidoId, CancellationToken cancellationToken = default);
        Task<Pedido> UpdateItemAsync(Guid pedidoId, Guid itemPedidoId, ItemPedidoUpdateInputDto updatedItemPedido, CancellationToken cancellationToken = default);
        Task<Pedido> UpdatePedidoAsync(Guid id, PedidoUpdateInputDto updatedPedido, CancellationToken cancellationToken = default);
    }
}