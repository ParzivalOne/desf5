using Microsoft.AspNetCore.Mvc;
using WebStore.DTOs;
using WebStore.Infrastructure.Repositories.Interfaces;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(IClienteService clienteService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ClienteOutputDto?> GetClienteByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var cliente = await clienteService.GetClienteByIdAsync(id, cancellationToken);
            return cliente?.ToOutputDto();
        }

        [HttpGet]
        public async Task<List<ClienteOutputDto>> GetAllClientesAsync(CancellationToken cancellationToken = default)
        {
            var clientes = await clienteService.GetAllClientesAsync(cancellationToken);
            return clientes.Select(cliente => cliente.ToOutputDto()).ToList();
        }

        [HttpGet("nome/{name}")]
        public async Task<List<ClienteOutputDto>> GetClientsByNameAsync([FromRoute] string name, CancellationToken cancellationToken = default)
        {
            var clientes = await clienteService.SearchClientesByNameAsync(name, cancellationToken);
            return clientes.Select(cliente => cliente.ToOutputDto()).ToList();
        }

        [HttpGet("count")]
        public async Task<long> GetClientesCountAsync(CancellationToken cancellationToken = default)
        {
            return await clienteService.GetClientesCountAsync(cancellationToken);
        }

        [HttpPost]
        public async Task<ClienteOutputDto> CreateClienteAsync([FromBody] ClienteCreateInputDto cliente, CancellationToken cancellationToken = default)
        {
            var createdCliente = await clienteService.CreateClienteAsync(cliente, cancellationToken);
            return createdCliente.ToOutputDto();
        }

        [HttpPatch("{id}")]
        public async Task<ClienteOutputDto> UpdateClienteAsync([FromRoute] Guid id, [FromBody] ClienteUpdateInputDto updatedCliente, CancellationToken cancellationToken = default)
        {
            var cliente = await clienteService.UpdateClienteAsync(id, updatedCliente, cancellationToken);
            return cliente.ToOutputDto();
        }

        [HttpDelete("{id}")]
        public async Task DeleteClienteAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            await clienteService.DeleteClientAsync(id, cancellationToken);
        }
    }
}
