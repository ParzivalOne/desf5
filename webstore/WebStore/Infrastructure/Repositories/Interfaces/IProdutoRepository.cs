using WebStore.DTOs;
using WebStore.Models;

namespace WebStore.Infrastructure.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> CreateProdutoAsync(ProdutoCreateInputDto produtoCreate, CancellationToken cancellationToken = default);
        Task DeleteProdutoAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Produto>> GetAllProdutosAsync(CancellationToken cancellationToken = default);
        Task<Produto?> GetProdutoByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Produto>> GetProdutoByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<long> GetProdutosCountAsync(CancellationToken cancellationToken = default);
        Task<Produto> UpdateProdutoAsync(Guid id, ProdutoUpdateInputDto updatedProduto, CancellationToken cancellationToken = default);
    }
}