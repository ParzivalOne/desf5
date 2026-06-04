using Microsoft.EntityFrameworkCore;
using WebStore.DTOs;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Repositories.Interfaces;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class ClienteService(IClienteRepository repository) : IClienteService
    {
        public async Task<Cliente?> GetClienteByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await repository.GetClienteByIdAsync(id, cancellationToken);

        public async Task<List<Cliente>> GetAllClientesAsync(CancellationToken cancellationToken = default)
            => await repository.GetAllClientesAsync(cancellationToken);

        public async Task<List<Cliente>> SearchClientesByNameAsync(string name, CancellationToken cancellationToken = default)
            => await repository.SearchClientesByNameAsync(name, cancellationToken);

        public async Task<Cliente> CreateClienteAsync(ClienteCreateInputDto clienteCreate, CancellationToken cancellationToken = default)
            => await repository.CreateClienteAsync(clienteCreate, cancellationToken);

        public async Task<Cliente> UpdateClienteAsync(Guid id, ClienteUpdateInputDto updatedCliente, CancellationToken cancellationToken = default)
            => await repository.UpdateClienteAsync(id, updatedCliente, cancellationToken);

        public async Task DeleteClientAsync(Guid id, CancellationToken cancellationToken = default)
            => await repository.DeleteClientAsync(id, cancellationToken);

        public async Task<long> GetClientesCountAsync(CancellationToken cancellationToken = default)
            => await repository.GetClientesCountAsync(cancellationToken);
    }
}
