using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> CreateClienteAsync(Cliente cliente, CancellationToken cancellationToken = default);
        Task DeleteClientAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Cliente?> GetClienteByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Cliente> UpdateClienteAsync(Guid id, Cliente updatedCliente, CancellationToken cancellationToken = default);
    }
}
