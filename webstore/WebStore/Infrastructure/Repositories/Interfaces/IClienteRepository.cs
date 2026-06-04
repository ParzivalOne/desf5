using WebStore.DTOs;
using WebStore.Models;

namespace WebStore.Infrastructure.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> CreateClienteAsync(ClienteCreateInputDto clienteUpdate, CancellationToken cancellationToken = default);
        Task DeleteClientAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Cliente>> GetAllClientesAsync(CancellationToken cancellationToken = default);
        Task<Cliente?> GetClienteByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<long> GetClientesCountAsync(CancellationToken cancellationToken = default);
        Task<List<Cliente>> SearchClientesByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Cliente> UpdateClienteAsync(Guid id, ClienteUpdateInputDto updatedCliente, CancellationToken cancellationToken = default);
    }
}
