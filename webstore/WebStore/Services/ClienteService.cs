using Microsoft.EntityFrameworkCore;
using WebStore.Infrastructure;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class ClienteService(WebStoreDBContext dbContext) : IClienteService
    {
        public async Task<Cliente?> GetClienteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Clientes.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente, CancellationToken cancellationToken = default)
        {
            cliente.Id = Guid.NewGuid();
            dbContext.Clientes.Add(cliente);
            await dbContext.SaveChangesAsync(cancellationToken);
            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Guid id, Cliente updatedCliente, CancellationToken cancellationToken = default)
        {
            var existingCliente = await dbContext.Clientes.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            if (existingCliente == null)
            {
                throw new KeyNotFoundException($"Cliente with ID {id} not found.");
            }
            existingCliente.Telefone = updatedCliente.Telefone;
            existingCliente.Email = updatedCliente.Email;
            // Update other properties as needed
            await dbContext.SaveChangesAsync(cancellationToken);
            return existingCliente;
        }

        public async Task DeleteClientAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var existingCliente = await dbContext.Clientes.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            if (existingCliente == null)
            {
                throw new KeyNotFoundException($"Cliente with ID {id} not found.");
            }
            dbContext.Clientes.Remove(existingCliente);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
