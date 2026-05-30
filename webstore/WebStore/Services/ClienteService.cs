using Microsoft.EntityFrameworkCore;
using WebStore.DTOs;
using WebStore.Infrastructure;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class ClienteService(WebStoreDBContext dbContext) : IClienteService
    {
        public async Task<Cliente?> GetClienteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Clientes
                .Include(cliente => cliente.Pedidos)
                .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<List<Cliente>> GetAllClientesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Clientes
                .ToListAsync(cancellationToken);
        }

        public async Task<Cliente> CreateClienteAsync(ClienteCreateInputDto clienteCreate, CancellationToken cancellationToken = default)
        {
            var cliente = Cliente.MapFrom(clienteCreate);

            cliente.Id = Guid.NewGuid();
            dbContext.Clientes.Add(cliente);
            await dbContext.SaveChangesAsync(cancellationToken);
            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Guid id, ClienteUpdateInputDto updatedCliente, CancellationToken cancellationToken = default)
        {
            var existingCliente = await dbContext.Clientes.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            if (existingCliente == null)
            {
                throw new KeyNotFoundException($"Cliente with ID {id} not found.");
            }
            existingCliente.Telefone = updatedCliente.Telefone ?? existingCliente.Telefone;
            existingCliente.Email = updatedCliente.Email ?? existingCliente.Email;
            
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
