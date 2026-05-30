using Microsoft.AspNetCore.Mvc;
using WebStore.DTOs;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController(IPedidoService pedidoService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<PedidoOutputDto?> GetPedidoByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var pedido = await pedidoService.GetPedidoByIdAsync(id, cancellationToken);
            return pedido?.ToOutputDto();
        }

        [HttpGet]
        public async Task<List<PedidoOutputDto>> GetAllPedidosAsync(CancellationToken cancellationToken = default)
        {
            var pedidos = await pedidoService.GetAllPedidosAsync(cancellationToken);
            return pedidos.Select(pedido => pedido.ToOutputDto()).ToList();
        }

        [HttpPost]
        public async Task<PedidoOutputDto> CreatePedidoAsync([FromBody] PedidoCreateInputDto pedido, CancellationToken cancellationToken = default)
        {
            var createdPedido = await pedidoService.CreatePedidoAsync(pedido, cancellationToken);
            return createdPedido.ToOutputDto();
        }

        [HttpPatch("{id}")]
        public async Task<PedidoOutputDto> UpdatePedidoAsync([FromRoute] Guid id, [FromBody] PedidoUpdateInputDto updatedPedido, CancellationToken cancellationToken = default)
        {
            var pedido = await pedidoService.UpdatePedidoAsync(id, updatedPedido, cancellationToken);
            return pedido.ToOutputDto();
        }

        [HttpPost("{pedidoId}/itens")]
        public async Task<PedidoOutputDto> AddItemAsync([FromRoute] Guid pedidoId, [FromBody] ItemPedidoCreateInputDto itemPedidoCreate, CancellationToken cancellationToken = default)
        {
            var pedido = await pedidoService.AddItemAsync(pedidoId, itemPedidoCreate, cancellationToken);
            return pedido.ToOutputDto();
        }

        [HttpPatch("{pedidoId}/itens/{itemId}")]
        public async Task<PedidoOutputDto> UpdateItemAsync([FromRoute] Guid pedidoId, [FromRoute] Guid itemId, [FromBody] ItemPedidoUpdateInputDto updatedItemPedido, CancellationToken cancellationToken = default)
        {
            var pedido = await pedidoService.UpdateItemAsync(pedidoId, itemId, updatedItemPedido, cancellationToken);
            return pedido.ToOutputDto();
        }

        [HttpDelete("{pedidoId}/itens/{itemId}")]
        public async Task<PedidoOutputDto> RemoveItemAsync([FromRoute] Guid pedidoId, [FromRoute] Guid itemId, CancellationToken cancellationToken = default)
        {
            var pedido = await pedidoService.RemoveItemAsync(pedidoId, itemId, cancellationToken);
            return pedido.ToOutputDto();
        }

        [HttpDelete("{id}")]
        public async Task DeletePedidoAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            await pedidoService.DeletePedidoAsync(id, cancellationToken);
        }
    }
}
