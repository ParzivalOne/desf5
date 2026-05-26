using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(IClienteService clienteService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<Cliente?> GetClienteByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var cliente = await clienteService.GetClienteByIdAsync(id, cancellationToken);
            return cliente;
        }

        [HttpPost]
        public async Task<Cliente> CreateClienteAsync([FromBody] Cliente cliente, CancellationToken cancellationToken = default)
        {
            var createdCliente = await clienteService.CreateClienteAsync(cliente, cancellationToken);
            return createdCliente;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateClienteAsync([FromRoute] Guid id, [FromBody] Cliente updatedCliente, CancellationToken cancellationToken = default)
        {
            try
            {
                var cliente = await clienteService.UpdateClienteAsync(id, updatedCliente, cancellationToken);
                return Ok(cliente);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        public async Task<IActionResult> DeleteClienteAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            await clienteService.DeleteClientAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
